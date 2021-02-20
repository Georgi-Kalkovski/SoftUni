class Story {
    constructor(title, creator) {
        this.title = title;
        this.creator = creator;
        this.comments = [];
        this.likesProp = [];
    }

    get likes() {
        if (this.likesProp.length === 0) {
            return `${this.title} has 0 likes`;
        }
        if (this.likesProp.length === 1) {
            return `${this.likesProp[0]} likes this story!`;
        }
        return `${this.likesProp[0]} and ${this.likesProp.length - 1} others like this story!`;
    }

    set likes(value) {

    }

    like(username) {
        if (this.likesProp.find(x => x == username)) {
            throw new Error("You can't like the same story twice!");
        }
        if (username == this.creator) {
            throw new Error("You can't like your own story!");
        }
        this.likesProp.push(username);
        return `${username} liked ${this.title}!`;
    }

    dislike(username) {
        const dislikeIndex = this.likesProp.indexOf(username);
        if (dislikeIndex < 0) {
            throw new Error("You can't dislike this story!");
        } else {
            this.likesProp.splice(dislikeIndex, 1);
        }

        return `${username} disliked ${this.title}`;
    }

    comment(username, content, id) {
        const findCommentById = this.comments.find(x => x.id === id);
        if (typeof id === 'undefined' || !findCommentById) {
            const sortedComments = this.comments.map(el => el.id).sort((a, b) => b - a);
            if (sortedComments.length) {
                id = sortedComments[0] + 1;
            } else {
                id = 1;
            }
            this.comments.push({ id, username, content, replies: [] });

            return `${username} commented on ${this.title}`
        }
        if (findCommentById) {
            let commentReplies = findCommentById.replies;
            let replyId = 1;
            const sortedReplies = commentReplies.map(reply => reply.id).sort((a, b) => b - a);
            if (sortedReplies.length) {
                replyId = sortedReplies[0] + 1;
            }
            commentReplies.push({ id: replyId, username, content });
            findCommentById.replies = commentReplies;
            const commentId = this.comments.indexOf(findCommentById);
            this.comments[commentId] = findCommentById
            console.log(this.comments);

            return "You replied successfully";
        }
    }

    toString(sortingType) {
        let result = [
            `Title: ${this.title}`,
            `Creator: ${this.creator}`,
            `Likes: ${this.likesProp.length}`,
            `Comments:`,
        ];

        this.comments.sort((a, b) => {
            if (sortingType === 'asc') {
                return a.id - b.id;
            } else if (sortingType === 'desc') {
                return b.id - a.id;
            } else if (sortingType === 'username') {
                if (a.username < b.username) {
                    return -1;
                } else {
                    return 1;
                }
            }
        })
            .forEach(comment => {
                result.push(`-- ${comment.id}. ${comment.username}: ${comment.content}`);
                if (comment.replies.length) {
                    comment.replies.sort((a, b) => {
                        if (sortingType === 'asc') {
                            return a.id - b.id;
                        } else if (sortingType === 'desc') {
                            return b.id - a.id;
                        } else if (sortingType === 'username') {
                            if (a.username < b.username) {
                                return -1;
                            } else {
                                return 1;
                            }
                        }
                    })
                        .forEach(reply => {
                            result.push(`--- ${comment.id}.${reply.id}. ${reply.username}: ${reply.content}`);
                        })
                }
            });

        return result.join('\n');
    }
}

let art = new Story("My Story", "Anny");
art.like("John");
console.log(art.likes);
art.dislike("John");
console.log(art.likes);
art.comment("Sammy", "Some Content");
console.log(art.comment("Ammy", "New Content"));
art.comment("Zane", "Reply", 1);
art.comment("Jessy", "Nice :)");
console.log(art.comment("SAmmy", "Reply@", 1));
console.log()
console.log(art.toString('username'));
console.log()
art.like("Zane");
console.log(art.toString('desc'));
