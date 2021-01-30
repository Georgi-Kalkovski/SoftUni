function solve() {
  let text = document.getElementById("text").value;
  let convention = document.getElementById("naming-convention").value;
  let result;
  if (convention == "Camel Case") {
    result = text.replace(/\w+/g,
      function (w) { return w[0].toUpperCase() + w.slice(1).toLowerCase(); }).replace(/\s/g, '');
    result = result.charAt(0).toLowerCase() + result.slice(1);
  }
  else if (convention == "Pascal Case") {
    result = text.replace(/\w+/g,
      function (w) { return w[0].toUpperCase() + w.slice(1).toLowerCase(); }).replace(/\s/g, '');
  }
  else {
    result = "Error!";
  }
  document.getElementById('result').textContent = result;
}