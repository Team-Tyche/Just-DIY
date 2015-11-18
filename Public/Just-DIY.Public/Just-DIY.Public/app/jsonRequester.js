var jsonRequester = (function () {

    var LOCAL_STORAGE_USERNAME_KEY = 'signed-in-user-username',
        LOCAL_STORAGE_AUTHKEY_KEY = 'signed-in-user-auth-key',
        LOCAL_STORAGE_IS_LOGEED = 'signed-in-user-bool';

    function send(method, url, options) {
        options = options || {};

        var headers = options.headers || {},
          data = options.data || undefined;

        var promise = new Promise(function (resolve, reject) {
            $.ajax({
                url: url,
                method: method,
                contentType: 'application/json',
                headers: headers,
                data: JSON.stringify(data),
                success: function (res) {
                    resolve(res);
                },
                error: function (err) {
                    reject(err);
                }
            });
        });
        return promise;
    }

    function get(url, options) {
        return send('GET', url, options);
    }

    function post(url, options) {
        return send('POST', url, options);
    }

    function put(url, options) {
        return send('PUT', url, options);
    }

    function del(url, options) {
        return send('DELETE', url, options);
    }

    function token(url, obj)
    {
        $.ajax({
            method: 'POST',
            url: url,
            headers: { 'Content-Type': 'application/x-www-form-urlencoded' },
            transformRequest: function (obj) {
                var str = [];
                for (var p in obj)
                    str.push(encodeURIComponent(p) + "=" + encodeURIComponent(obj[p]));
                return str.join("&");
            },
            data: obj
        }).success(function (resp) {
            localStorage.setItem(LOCAL_STORAGE_USERNAME_KEY, resp.userName);
            localStorage.setItem(LOCAL_STORAGE_AUTHKEY_KEY, resp.access_token);
            localStorage.setItem(LOCAL_STORAGE_IS_LOGEED, true);
            toastr.success('People who think they know everything are a great annoyance to those of us who do.', 'Isaak Asimov');
        });
    }

    return {
        send: send,
        get: get,
        post: post,
        put: put,
        delete: del,
        token: token
    };
}());