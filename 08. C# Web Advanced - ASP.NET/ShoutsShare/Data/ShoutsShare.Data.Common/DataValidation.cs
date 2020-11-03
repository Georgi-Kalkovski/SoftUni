namespace ShoutsShare.Data.Common
{
    public static class DataValidation
    {
        public const int NameMaxLength = 30;
        public const int FullNameMaxLength = 60;

        public static class Video
        {
            public const int NameMaxLength = 60;
            public const int DescriptionMaxLength = 1100;
            public const int LanguageMaxLength = 50;
            public const int CoverPathMaxLength = 500;
            public const int ThumbnailPathMaxLength = 500;
            public const int YoutubeLinkMaxLength = 500;
        }

        public static class Country
        {
            public const int NameMaxLength = 40;
        }

        public static class Genre
        {
            public const int NameMaxLength = 30;
        }

        public static class Review
        {
            public const int TitleMaxLength = 100;
            public const int DescriptionMaxLength = 1500;
        }

        public static class News
        {
            public const int TitleMaxLength = 100;
            public const int DescriptionMaxLength = 10000;
            public const int ShortDescriptionMaxLength = 400;
            public const int ImagePathMaxLength = 500;
        }
    }
}
