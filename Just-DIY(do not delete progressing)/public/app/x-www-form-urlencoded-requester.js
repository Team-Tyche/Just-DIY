var xWwwFormRequester = (function() {

    function send(method, url, options) {
        options = options || {};
        url = 'http://localhost:29004/'+ url;

        var headers = options.headers || {},
            data = options.data || undefined;

        var promise = new Promise(function(resolve, reject) {
            $.ajax({
                url: url,
                method: method,
                contentType: 'application/x-www-form-urlencoded',
                headers: headers,
                data: data,
                success: function(res) {
                    resolve(res);
                },
                error: function(err) {
                    reject(err);
                }
            });
        });
        return promise;
    }



    function post(url, options) {
        return send('POST', url, options);
    }


    return {
        post: post
    };
}());
