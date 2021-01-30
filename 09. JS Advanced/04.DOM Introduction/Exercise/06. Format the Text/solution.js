function solve() {
  const textArea = document.getElementById('input');
  const paragraph = textArea.value.split('.').filter((x) => x != '');
  let paragraphs = '';

  while (paragraph.length) {
    paragraphs += `<p>${paragraph.splice(0, 3).join('. ')}.</p>`;
  }

  document.getElementById('output').innerHTML = paragraphs;
}