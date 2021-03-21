export {validateInput}

function validateInput(form, data) {
    let isValid = true;
    const makeField = form.querySelector('input[name="make"]');
    const modelField = form.querySelector('input[name="model"]');
    const yearField = form.querySelector('input[name="year"]');
    const descrField = form.querySelector('input[name="description"]');
    const priceField = form.querySelector('input[name="price"]');
    const urlField = form.querySelector('input[name="img"]');

    //check make
    if (data.make.length < 4) {
        isValid = false;
        makeField.classList.add('is-invalid');
        makeField.classList.remove('is-valid');
    } else {
        makeField.classList.add('is-valid');
        makeField.classList.remove('is-invalid');
    }
    //check model
    if (data.model.length < 4) {
        isValid = false;
        modelField.classList.add('is-invalid');
        modelField.classList.remove('is-valid');
    } else {
        modelField.classList.add('is-valid');
        modelField.classList.remove('is-invalid');
    }

    //check year
    if (data.year < 1950 || data.year > 2050) {
        isValid = false;
        yearField.classList.add('is-invalid');
        yearField.classList.remove('is-valid');
    } else {
        yearField.classList.add('is-valid');
        yearField.classList.remove('is-invalid');
    }

    //check description
    if (data.description.length < 10) {
        isValid = false;
        descrField.classList.add('is-invalid');
        descrField.classList.remove('is-valid');
    } else {
        descrField.classList.add('is-valid');
        descrField.classList.remove('is-invalid');
    }

    //check price
    if (data.price <= 0) {
        isValid = false;
        priceField.classList.add('is-invalid');
        priceField.classList.remove('is-valid');
    } else {
        priceField.classList.add('is-valid');
        priceField.classList.remove('is-invalid');
    }

    //check url
    if (data.img.length === 0) {
        isValid = false;
        urlField.classList.add('is-invalid');
        urlField.classList.remove('is-valid');
    } else {
        urlField.classList.add('is-valid');
        urlField.classList.remove('is-invalid');
    }

    return isValid;
}