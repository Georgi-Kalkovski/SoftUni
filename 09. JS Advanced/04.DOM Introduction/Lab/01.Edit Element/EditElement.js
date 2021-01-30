function editElement(ref, match, replacer) {
    let content = ref.textContent;
    let matcher = new RegExp(match, 'g');
    let edited = content.replace(matcher, replacer);
    ref.textContent = edited;
}