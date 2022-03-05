var CustomRequest = /** @class */ (function () {
    function CustomRequest(method, uri, version, message) {
        this.method = method;
        this.uri = uri;
        this.version = version;
        this.message = message;
        this.response = undefined;
        this.fulfilled = false;
    }
    return CustomRequest;
}());
var data = new CustomRequest('GET', 'http://google.com', 'HTTP/1.1', '');
console.log(data);
