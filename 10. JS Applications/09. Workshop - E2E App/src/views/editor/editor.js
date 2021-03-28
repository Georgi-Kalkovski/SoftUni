import { topics, html, render } from '../../lib.js';
import { createList } from './list.js';
import { createQuiz, updateQuiz, getQuizById, getQuestionsByQuizId } from '../../api/data.js';


const template = (quiz, quizEditor, updateCount) => html`
<section id="editor">

    <header class="pad-large">
        <h1>${quiz ? 'Edit Quiz' : 'New Quiz'}</h1>
    </header>

    ${quizEditor}

    ${quiz ? createList(quiz.objectId, quiz.questions, updateCount) : ''}

</section>`;


const quizEditorTemplate = (quiz, onSave, working) => html`
<form @submit=${onSave}>
    <label class="editor-label layout">
        <span class="label-col">Title:</span>
        <input class="input i-med" type="text" name="title" .value=${quiz ? quiz.title : ''} ?disabled=${working}>
    </label>
    <label class="editor-label layout">
        <span class="label-col">Topic:</span>
        <select class="input i-med" name="topic" .value=${quiz ? quiz.topic : '0'} ?disabled=${working}>
            <option value="0">-- Select category</option>
            ${Object.entries(topics).map(([k, v]) => html`<option value=${k} ?selected=${quiz.topic == k} >${v}</option>`)}
        </select>
    </label>
    <label class="editor-label layout">
        <span class="label-col">Description:</span>
        <textarea class="input" name="description" .value=${quiz ? quiz.description : ''}
            ?disabled=${working}></textarea>
    </label>
    <input class="input submit action" type="submit" value="Save">
</form>

${working ? html`<div class="loading-overlay working"></div>` : ''}`;


function createQuizEditor(quiz, onSave) {
    const editor = document.createElement('div');
    editor.className = 'pad-large alt-page';
    update();

    return {
        editor,
        updateEditor: update
    };

    function update(working) {
        render(quizEditorTemplate(quiz, onSave, working), editor);
    }
}

export async function editorPage(ctx) {
    const quizId = ctx.params.id;
    let quiz = null;
    let questions = [];
    if (quizId) {
        [quiz, questions] = await Promise.all([
            getQuizById(quizId),
            getQuestionsByQuizId(quizId, sessionStorage.getItem('userId'))
        ]);
        quiz.questions = questions;
    }

    const { editor, updateEditor } = createQuizEditor(quiz, onSave);

    ctx.render(template(quiz, editor, updateCount));

    async function updateCount(change = 0) {
        const count = questions.length + change;
        await updateQuiz(quizId, { questionCount: count });
    }

    async function onSave(event) {
        event.preventDefault();
        const formData = new FormData(event.target);

        const title = formData.get('title');
        const topic = formData.get('topic');
        const description = formData.get('description');

        const data = {
            title,
            topic,
            description,
            questionCount: questions.length
        };

        try {
            updateEditor(true);

            if (quizId) {
                await updateQuiz(quizId, data);
            } else {
                const result = await createQuiz(data);
                ctx.page.redirect('/edit/' + result.objectId);
            }
        } catch (err) {
            console.error(err);
        } finally {
            updateEditor(false);
        }
    }
}