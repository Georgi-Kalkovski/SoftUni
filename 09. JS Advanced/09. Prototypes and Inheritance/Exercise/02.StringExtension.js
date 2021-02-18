(function () {
    String.prototype.ensureStart = function (str) {
        if (!this.startsWith(str)) {
            return str + this
        }
        return this.slice(0)
    }
    String.prototype.ensureEnd = function (str) {
        if (!this.endsWith(str)) {
            return this + str
        }
        return this.slice(0)
    }
    String.prototype.isEmpty = function () {
        return this == '' ? true : false
    }
    String.prototype.truncate = function (n) {
        if (this.length <= n) {
            return this.slice(0)
        } else if (n < 4) {
            return '.'.repeat(n)
        }
        else if (this.length > n) {
            let isSpaces = this.split(' ').length > 1
            if (isSpaces) {
                let index = this.substring(0, n).trim().lastIndexOf(' ')
                if (index != -1) {
                    return this.substring(0, index) + '...'
                } else {
                    return this.substring(0, n) + '...'
                }
            } else {
                n = this.endsWith('...') ? n + 3 : n
                return this.slice(0, -n) + '...'
            }
        }
    }
    String.format = function (str, ...params) {
        params.forEach((el, i) => {
            if (str.includes(`{${i}}`)) {
                str = str.replace(`{${i}}`, el)
            }
        })
        return str
    }

}())
let str = 'the quick brown fox jumps over the lazy dog';
console.log(str.length)
str = str.truncate(45)


console.log(str)