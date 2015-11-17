var templates = function () {
    function get(name) {
        var promise = new Promise(function (resolve, reject) {
            var url = 'templates/' + name + '.html';
            $.get(url, function (html) {
                resolve(html);
            });
        });
        return promise;
    }

    return {
        get: get
    };
}();