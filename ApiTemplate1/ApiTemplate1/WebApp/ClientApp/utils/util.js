globalThis.secureFetch = function (url, obj) {
	if (obj.headers == undefined) obj.headers = {};
	obj.headers["authToken"] = identityToken();
	return fetch(url, obj).then(r => {
		var token = r.headers.get("authToken");
		return r;
	});
}


globalThis.identityToken = function (t) {
	if (!t) {
		return localStorage.getItem("token");
	}
	localStorage.setItem("token", t);
}