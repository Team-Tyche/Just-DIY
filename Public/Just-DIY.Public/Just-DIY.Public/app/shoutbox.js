var pubnub = PUBNUB({
    subscribe_key: 'sub-c-1e0398c4-8d08-11e5-bf00-02ee2ddab7fe', // always required
    publish_key: 'pub-c-c255ff42-fad4-423c-8738-32a6bb7ba90d'    // only required if publishing
});

pubnub.subscribe({
    channel: 'Just-DIY',
    message: function (m) {
        var $chat = $('#chat');
        $chat.html($chat.html() + '<p style="color: black; margin: 0; padding: 0; font-size: 0.8em; line-height: 0.99em">' + m + '</p>');
        var chat = document.getElementById('chat');
        chat.scrollTop = chat.scrollHeight;
    }
});

var pubPub = function (message) {
    pubnub.publish({
        channel: 'Just-DIY',
        message: message
    });
}