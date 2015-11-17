var data = (function() {
  const USERNAME_LOCAL_STORAGE_KEY = 'signed-in-user-username',
    AUTH_KEY_LOCAL_STORAGE_KEY = 'signed-in-user-auth-key';
  /* Users */

  function register(user) {
    var reqUser = {
      email: user.username,
      password: CryptoJS.SHA1(user.username + user.password).toString(),
      confirmPassword:CryptoJS.SHA1(user.username + user.password).toString()

    };

    return jsonRequester.post('api/Account/Register', {
        data: reqUser
      })
      .then(function(resp) {
        var user = resp.result;
        return {
          username: resp.result.username
        };
      });
  }

  function signIn(user) {
    var reqUser = {
      username: user.username,
      password: user.password,
       grant_type:"password"//CryptoJS.SHA1(user.username + user.password).toString()
    };

    var options = {
      data: reqUser
    };

    return xWwwFormRequester.post('Token', options)
      .then(function(resp) {
        var user = resp.result;
        localStorage.setItem(USERNAME_LOCAL_STORAGE_KEY, user.username);
        localStorage.setItem(AUTH_KEY_LOCAL_STORAGE_KEY, user.authKey);
        return user;
      });
  }

  function signOut() {
    var promise = new Promise(function(resolve, reject) {
      localStorage.removeItem(USERNAME_LOCAL_STORAGE_KEY);
      localStorage.removeItem(AUTH_KEY_LOCAL_STORAGE_KEY);
      resolve();
    });
    return promise;
  }

  function hasUser() {
    return !!localStorage.getItem(USERNAME_LOCAL_STORAGE_KEY) &&
      !!localStorage.getItem(AUTH_KEY_LOCAL_STORAGE_KEY);
  }

  function usersGet() {
    var options = {
      headers: {
        'x-auth-key': localStorage.getItem(AUTH_KEY_LOCAL_STORAGE_KEY)
      }
    };
    return jsonRequester.get('api/users', options)
      .then(function(res) {
        return res.result;
      });
  }

  /* Cookies start*/

  function projectsGet() {
    return jsonRequester.get('api/Projects')
      .then(function(res) {
        return res.result;
      });
  }

  function projectsAdd(project) {
    var options = {
      headers: {
        'x-auth-key': localStorage.getItem(AUTH_KEY_LOCAL_STORAGE_KEY)
      },
      data: project
    };
    return jsonRequester.post('api/Projects', options)
      .then(function(res) {
        return res.result;
      });
  }

  function projectsLike(id) {
    var options = {
      headers: {
        'x-auth-key': localStorage.getItem(AUTH_KEY_LOCAL_STORAGE_KEY)
      },
      data: {
        type: 'like'
      }
    };

    return jsonRequester.put('api/cookies/' + id, options)
      .then(function(res) {
        return res.result;
      });
  }

  function projectsDislike(id) {
    var options = {
      headers: {
        'x-auth-key': localStorage.getItem(AUTH_KEY_LOCAL_STORAGE_KEY)
      },
      data: {
        type: 'dislike'
      }
    };

    return jsonRequester.put('api/cookies/' + id, options)
      .then(function(res) {
        return res.result;
      });
  }

  /* Cookies end */


  /* My Cookies start */

  function myCookiesGet() {
    var options = {
      headers: {
        'x-auth-key': localStorage.getItem(AUTH_KEY_LOCAL_STORAGE_KEY)
      }
    };
    return jsonRequester.get('api/my-project', options)
      .then(function(res) {
        return res.result;
      });
  }

  /* My Cookies end */

  /* Categories start */

  function categoriesGet() {
    return jsonRequester.get('api/categories')
      .then(function(res) {
        return res.result;
      });
  }
  /* Categories end */


  return {
    users: {
      register: register,
      signIn: signIn,
      signOut: signOut,
      hasUser: hasUser,
      get: usersGet
    },
    projects: {
      get: projectsGet,
      add: projectsAdd,
      like: projectsLike,
      dislike: projectsDislike
    },
    myCookies: {
      get: myCookiesGet
    },
    categories: {
      get: categoriesGet
    }
  };

}());
