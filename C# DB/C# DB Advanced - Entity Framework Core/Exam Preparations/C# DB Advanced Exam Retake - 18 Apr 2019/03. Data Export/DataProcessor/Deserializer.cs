namespace MusicHub.DataProcessor
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;
    using Castle.DynamicProxy;
    using Data;
    using MusicHub.Data.Models;
    using MusicHub.Data.Models.Enums;
    using MusicHub.DataProcessor.ImportDtos;
    using Newtonsoft.Json;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data";

        private const string SuccessfullyImportedWriter
            = "Imported {0}";
        private const string SuccessfullyImportedProducerWithPhone
            = "Imported {0} with phone: {1} produces {2} albums";
        private const string SuccessfullyImportedProducerWithNoPhone
            = "Imported {0} with no phone number produces {1} albums";
        private const string SuccessfullyImportedSong
            = "Imported {0} ({1} genre) with duration {2}";
        private const string SuccessfullyImportedPerformer
            = "Imported {0} ({1} songs)";

        public static string ImportWriters(MusicHubDbContext context, string jsonString)
        {
            var writersDto = JsonConvert.DeserializeObject<List<ImportWritersDto>>(jsonString);
            var sb = new StringBuilder();
            var writers = new List<Writer>();

            foreach (var writerDto in writersDto)
            {
                if (!IsValid(writerDto))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var writer = new Writer
                {
                    Name = writerDto.Name,
                    Pseudonym = writerDto.Pseudonym
                };

                if (writers.Contains(writer))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                writers.Add(writer);
                sb.AppendLine(String.Format(SuccessfullyImportedWriter, writer.Name));
            }

            context.AddRange(writers);
            context.SaveChanges();

            return sb.ToString().Trim();
        }

        public static string ImportProducersAlbums(MusicHubDbContext context, string jsonString)
        {
            var producersDto = JsonConvert.DeserializeObject<List<ImportProducersAndAlbumsDto>>(jsonString);
            var sb = new StringBuilder();
            var producers = new List<Producer>();

            foreach (var producerDto in producersDto)
            {
                if (!IsValid(producerDto) || !producerDto.Albums.All(IsValid))
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var producer = new Producer
                {
                    Name = producerDto.Name,
                    Pseudonym = producerDto.Pseudonym,
                    PhoneNumber = producerDto.PhoneNumber
                };

                foreach (var albumDto in producerDto.Albums)
                {
                    var album = new Album
                    {
                        Name = albumDto.Name,
                        ReleaseDate = DateTime.ParseExact(albumDto.ReleaseDate, "dd/MM/yyyy", CultureInfo.InvariantCulture)
                    };

                    producer.Albums.Add(album);

                }

                string message = producer.PhoneNumber == null
                    ? string.Format(SuccessfullyImportedProducerWithNoPhone, producer.Name, producer.Albums.Count)
                    : string.Format(SuccessfullyImportedProducerWithPhone, producer.Name, producer.PhoneNumber, producer.Albums.Count);

                sb.AppendLine(message);

                producers.Add(producer);

            }

            context.AddRange(producers);
            context.SaveChanges();

            return sb.ToString().Trim();
        }

        public static string ImportSongs(MusicHubDbContext context, string xmlString)
        {
            var xmlSerializer = new XmlSerializer(typeof(List<ImportSongsDto>), new XmlRootAttribute("Songs"));

            var songsDto = (List<ImportSongsDto>)xmlSerializer.Deserialize(new StringReader(xmlString));

            var sb = new StringBuilder();
            var songs = new List<Song>();

            foreach (var performerDto in songsDto)
            {
                var genre = Enum.TryParse(performerDto.Genre, out Genre genreResult);
                var album = context.Albums.Find(performerDto.AlbumId);
                var writer = context.Writers.Find(performerDto.WriterId);

                if (!IsValid(performerDto) || !genre || album == null || writer == null)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }

                var song = new Song
                {
                    Name = performerDto.Name,
                    Duration = TimeSpan.ParseExact(performerDto.Duration, "c", CultureInfo.InvariantCulture),
                    CreatedOn = DateTime.ParseExact(performerDto.CreatedOn, "dd/MM/yyyy", CultureInfo.InvariantCulture),
                    Genre = genreResult,
                    AlbumId = performerDto.AlbumId,
                    WriterId = performerDto.WriterId,
                    Price = performerDto.Price,
                };

                songs.Add(song);
                sb.AppendLine(String.Format(SuccessfullyImportedSong, song.Name, song.Genre, song.Duration));
            }

            context.Songs.AddRange(songs);
            context.SaveChanges();

            return sb.ToString().Trim();
        }

        public static string ImportSongPerformers(MusicHubDbContext context, string xmlString)
        {
            var xmlSerializer = new XmlSerializer(typeof(List<ImportSongPerformersDto>), new XmlRootAttribute("Performers"));

            var performersDto = (List<ImportSongPerformersDto>)xmlSerializer.Deserialize(new StringReader(xmlString));

            var sb = new StringBuilder();
            var performers = new List<Performer>();

            foreach (var performerDto in performersDto)
            {
                var validSongs = true;
                foreach (var songId in performerDto.PerformerSongs)
                {
                    if (context.Songs.All(x => x.Id != songId.Id))
                    {
                        validSongs = false;
                        break;
                    }
                }
                if (!IsValid(performerDto) || !validSongs)
                {
                    sb.AppendLine(ErrorMessage);
                    continue;
                }
                var performer = new Performer
                {
                    FirstName = performerDto.FirstName,
                    LastName = performerDto.LastName,
                    Age = performerDto.Age,
                    NetWorth = performerDto.NetWorth

                };

                foreach (var songDto in performerDto.PerformerSongs)
                {
                    var song = context.Songs.FirstOrDefault(x => x.Id == songDto.Id);

                    performer.PerformerSongs.Add(new SongPerformer { Performer = performer, Song = song });
                }
                performers.Add(performer);
                sb.AppendLine(string.Format(SuccessfullyImportedPerformer, performer.FirstName, performer.PerformerSongs.Count));
            }
            context.Performers.AddRange(performers);
            context.SaveChanges();
            return sb.ToString().TrimEnd();
        }

        private static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, validationResult, true);
        }
    }
}