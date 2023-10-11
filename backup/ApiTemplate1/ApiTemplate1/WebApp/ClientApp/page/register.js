

import { AddUserProfile } from "../services/userservice.js";


var css = `
.register
{
	position: absolute;
	top: 50vh;
	left: 50vw;
	transform: translate(-50%, -50%);
	display:inline-block;
	padding: 3mm;
	border-radius: 3mm;
	border: 1px solid #000;
}
.register input
{
	border: 1px solid #000;
	border-radius: 2mm;
	padding: 0 1mm;
	
}
`;
var html = `
<c tt="page" to="page">
	<span class="register">
		<table>
			<tr>
				<td align="center" colspan="2">
					<h2>Register</h2>
				</td>
			</tr>
			<tr>
				<td align="right">
					First Name:
				</td>
				<td>
					<input type="text" tke="onchange" tr="user.firstName:value"></input>
				</td>
			</tr>
			<tr>
				<td align="right">
					Last Name:
				</td>
				<td>
					<input type="text" tke="onchange" tr="user.lastName:value"></input>
				</td>
			</tr>
			<tr>
				<td align="right">
					Email:
				</td>
				<td>
					<input type="text" tke="onchange" tr="user.email:value"></input>
				</td>
			</tr>
			<tr>
				<td align="right">
					Password:
				</td>
				<td>
					<input type="password" tke="onchange" tr="user.passwordHash:value"></input>
				</td>
			</tr>
			<tr>
				<td >
					<c tt="button" te="create:onclick">Create</c>
				</td>
				<td align="right">
					<c tt="linkButton" te="gotoLogin:onclick">Login</c>
				</td>
			</tr>
		</table>
	</span>
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
		user: {
			firstName: "",
			lastName: "",
			email: "",
			passwordHash: ""
		},
		create() {
			console.log("user");
			console.log(at.user);
			AddUserProfile(at.user)
				.then(d => {
					console.log("here1");
					console.log(d);
					if (d.statusCode != undefined && d.statusCode != 200) {
						at.errorModal.show = 1;
						$.msgc.send("show error modal", d.message);
					}
				})
				.catch(s => {
					console.log("here2");
					console.log(s);
				});
		},
		gotoLogin() {
			$.msgc.send("show login");
		},
		beforeinit() {
			$.msgc.subscribe("show register", function () {
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

$.comp("register", o);