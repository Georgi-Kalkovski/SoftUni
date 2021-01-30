function solve() {
   document.querySelector('#searchBtn').addEventListener('click', onClick);
   let rows = document.querySelectorAll('tbody tr');
   function onClick() {
      
      let search = document.getElementById('searchField').value;
   
      for (let row of rows) {
         if(row.textContent.includes(search)){
            row.classList.add('select');
         }
         else{
            row.classList.remove('select');
         }
      }
   }
}