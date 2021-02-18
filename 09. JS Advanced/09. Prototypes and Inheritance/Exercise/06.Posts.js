function solve() {

    class Post {
        constructor(title, content) {
            this.title = title;
            this.content = content;
        }

        toString() {
            return `Post: ${this.title}\nContent: ${this.content}`
        }

    }

    class SocialMediaPost extends Post {
        constructor(title, content, likes, dislikes) {
            super(title, content);
            this.likes = likes;
            this.dislikes = dislikes;
            this.commetns = [];
        }

        addComment(com) {
            this.commetns.push(com);
        }

        toString() {
            let result = `Post: ${this.title}\nContent: ${this.content}\nRating: ${this.likes - this.dislikes}`;

            if (this.commetns.length > 0) {
                result += '\nComments:\n';
                result += ' * ' + this.commetns.join('\n * ');
            }
            return result;
        }
    }

    class BlogPost extends Post {
        constructor(title, content, views) {
            super(title, content);
            this.views = views;
        }

        view() {
            this.views++;
            return this;
        }

        toString() {
            return `Post: ${this.title}\nContent: ${this.content}\nViews: ${this.views}`;
        }
    }

    return { Post, SocialMediaPost, BlogPost };
}

let tokens = solve();

let post = new tokens.Post('Post', 'Content');
console.log(post.toString());
// Post: Post
// Content: Content
let scm = new tokens.SocialMediaPost('TestTitle', 'TestContent', 25, 30);
scm.addComment('Good post');
scm.addComment('Very good post');
scm.addComment('Wow!');
console.log(scm.toString());