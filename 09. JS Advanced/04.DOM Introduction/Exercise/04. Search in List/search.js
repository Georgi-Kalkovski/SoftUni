function search() {
   let towns = document.querySelectorAll('#towns>li');
   let search = document.getElementById('searchText').value;

   counter = 0;
   for (const li of towns) {
      if(li.textContent.includes(search)){
         li.style.fontWeight = 'bold';
         li.style.textDecoration = 'underline';
         counter++;
      }
   }
   document.getElementById('result').textContent = counter + ' matches found';
}
