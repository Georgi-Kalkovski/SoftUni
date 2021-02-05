function solve() {
    let correctAnswers = [
      "onclick",
      "JSON.stringify()",
      "A programming API for HTML and XML documents",
    ];
  
    [...document.getElementsByTagName('p')].forEach(b => {
      b.addEventListener('click', getNextSection)
    });
  
    let sections = [...document.getElementsByTagName("section")];
  
    let counterCorrectAnswers = 0;
    let counterSections = 0;
  
    function getNextSection(event) {
      let currentAnswer = event.target.textContent;
  
      if (correctAnswers.includes(currentAnswer)) {
        counterCorrectAnswers++;
      }
  
      sections[counterSections].style.display = 'none';
      counterSections++;
  
      if (counterSections === sections.length) {
        let resultParent = document.getElementById("results");
        resultParent.style.display = "block";
  
        let resultInput = resultParent.children[0].children[0];
  
        if (counterCorrectAnswers === 3) {
          resultInput.textContent = "You are recognized as top JavaScript fan!";
        } else {
          resultInput.textContent = `You have ${counterCorrectAnswers} right answers`;
        }
  
      } else {
        sections[counterSections].style.display = "block";
      }
    }
  }