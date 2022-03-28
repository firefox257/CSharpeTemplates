

export function AddUserProfile(data)
{
	var url = "https://localhost:5001/api/v1/User/add";
	return fetch(url, {
		method: 'POST',
		headers: {
			'Content-Type': 'application/json'
			// 'Content-Type': 'application/x-www-form-urlencoded',
		},
		body: JSON.stringify(data),
	}).then(d=> d.json());
}

export function Login(data) {
	var url = "https://localhost:5001/api/v1/Identity/verify";
	return fetch(url, {
		method: 'POST',
		headers: {
			'Content-Type': 'application/json'
			// 'Content-Type': 'application/x-www-form-urlencoded',
		},
		body: JSON.stringify(data),
	}).then(d => d.json())
		.then(d => {
			if (d.statusCode == undefined) identityToken(d.token);
			return d;
		});
}
export function Logout() {
	identityToken("no token");
}
export function GetAllUsersProfiles() {
	var url = "https://localhost:5001/api/v1/User/all";
	return secureFetch(url, {
		method: 'GET',
	}).then(d => d.json());
}


