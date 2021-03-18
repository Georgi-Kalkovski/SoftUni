import {createIdea} from '../src/api/data.js'

export function setupCreate(section, navigation){
    return showCreate;

    async function showCreate(){
        section.querySelector('form').addEventListener('submit', create)
        return section;
    }

    async function create(e){
        e.preventDefault();
        const formData = new FormData(e.target);
        const title = formData.get('title');
        const description = formData.get('description');
        const img = formData.get('imageURL');
    
        if (!title || !description || !img) {
            return alert('All fields are required!');
        }
    
        if (title.length < 6) {
            return alert('Title should be at least 6 characters long!')
        }
    
        if (description.length < 10) {
            return alert('Description should be at least 10 characters long!')
        }
    
        if (img.length < 5) {
            return alert('Image URL should be at least 5 characters long!')
        }
    
        await createIdea({title, description, img});
        e.target.reset();
        navigation.loadPage('dashboard');
    }
}

