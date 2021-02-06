function solve() {
    let input = document.querySelectorAll("input");
    let onScreenBtn = document.querySelector("button");
    let sections = document.querySelectorAll("section");
    let movieSection = sections[0].children[1];
    let archiveSection = sections[1].children[1];
  
    let name = input[0];
    let hall = input[1];
    let price = input[2];
  
    onScreenBtn.addEventListener("click", function (e) {
      e.preventDefault();
      if (
        name.value === "" ||
        hall.value === "" ||
        price.value === "" ||
        Number(isNaN(Number(price.value)))
      ) {
        return;
      } else {
        let li = document.createElement("li");
        let div = document.createElement("div");
        let span1 = ce("span", name.value);
        let strong1 = ce("strong", `Hall: ${hall.value}`);
        let strong2 = ce("strong", price.value);
        let input = document.createElement("input");
        input.placeholder = "Tickets Sold";
        let archiveBtn = ce("button", "Archive");
        div.appendChild(strong2);
        div.appendChild(input);
        div.appendChild(archiveBtn);
        li.appendChild(span1);
        li.appendChild(strong1);
        li.appendChild(div);
        movieSection.appendChild(li);
  
        name.value = "";
        hall.value = "";
        price.value = "";
  
        archiveBtn.addEventListener("click", function (e) {
          if (Number.isNaN(Number(input.value)) || input.value === "") {
            return;
          } else {
            li.removeChild(div);
            let deleteBtn = ce("button", "Delete");
            strong1.textContent =
              "Total amount: " +
              (Number(input.value) * Number(strong2.textContent)).toFixed(2);
            li.appendChild(deleteBtn);
            archiveSection.appendChild(li);
  
            deleteBtn.addEventListener("click", function (e) {
              let parent = e.target.parentNode.parentNode;
              parent.removeChild(li);
            });
          }
        });
      }
    });
    let clearBtn = sections[1].children[2];
    clearBtn.addEventListener("click", function (e) {
      archiveSection.innerHTML = "";
    });
  
    function ce(el, text, className, id) {
      let e = document.createElement(el);
      if (text) {
        e.textContent = text;
      }
      if (className) {
        e.classList = className;
      }
      if (id) {
        e.id = id;
      }
      return e;
    }
  }