export function postCheck(topicName, username, postText) {
    if (topicName == '' || username == '' || postText == '') {
        if (topicName == '') { alert('Write Topic Name'); }
        else if (username == '') { alert('Write Username'); }
        else if (postText == '') { alert('Write Post Text'); }
        throw new Error('Empty input');
    }
}

export function commentCheck(username) {
    if (username == '') {
        alert('Write Username');
        throw new Error('Empty input');
    }
}