import { GetAllUsersProfiles, Logout } from "../services/userservice.js";

var css = `

`;
var html = `
<c tt="page" to="page">
	<c tt="button" t="logout:onclick">Logout</c><br/>
	hi there<br/>
	<c tt="button" t="getUsers:onclick">Get Users</c>
	<div t="listOut:innerHTML"></div>
</c>
`;

function o() {
	var at =
	{
		attr:
		{
			get show() {
				return at.page.show;
			},
			set show(v) {
				at.page.show = v;
			}
		},
		page: undefined,
		listOut:undefined,
		getUsers() {
			GetAllUsersProfiles().then(d => {
				
				if (d.statusCode != undefined && d.statusCode != 200) {

					$.msgc.send("show error modal", d.message, function () {
						
						$.msgc.send("show login");
					});

				}
				else {
					var html = "";
					d.users.map(item => {
						html += `first Name: ${item.firstName}|   Last Name: ${item.lastName}|   Email: ${item.email} <br/>`
					});
					at.listOut = html;
				}
			});
		},
		logout() {
			Logout();
			
		},
		beforeinit() {
			$.msgc.subscribe("show main", function () {
				at.attr.show = 1;
			});
		},
		init() {

		}
	};
	return at;
}
o.css = css;
o.html = html;

$.comp("main", o);