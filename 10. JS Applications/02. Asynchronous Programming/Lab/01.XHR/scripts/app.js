function loadRepos() {
   document.querySelector('button').addEventListener('click', () => {

      let URL = `https://api.github.com/users/testnakov/repos`;

      let request = new XMLHttpRequest();
      
      request.addEventListener('readystatechange', function () {
         if (request.readyState == 4 && request.status == 200) {
            document.getElementById('res').textContent = request.responseText;
         }
      })
      request.open('GET', URL);
      request.send();
   })
}
window.addEventListener('load', loadRepos);