
import { Login } from "../services/userservice.js";


var css = `
.login
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
.login input
{
	border: 1px solid #000;
	border-radius: 2mm;
	padding: 0 1mm;
	
}
.loginError
{
	color: #700;
}
`;
var html = `
<c tt="page" to="page">
	<span class="login">
		<table>
			<tr>
				<td align="center" colspan="2">
					<h2>Login</h2>
				</td>
			</tr>
			<tr>
				<td align="right">
					User Name:
				</td>
				<td>
					<input type="text" tke="onchange" tr="verify.userName:value"></input>
				</td>
			</tr>
			<tr>
				<td align="right">
					Password:
				</td>
				<td>
					<input type="password" tke="onchange" tr="verify.passwordHash:value"></input>
				</td>
			</tr>
			<tr>
				<td >
					<c tt="button" te="login:onclick">Login</c>
				</td>
				<td align="right">
					<c tt="linkButton" te="gotoRegister:onclick">Register</c>
				</td>
			</tr>
		</table>
	</span>
</c>
<c tt="modal" to="errorModel">
	<table>
		<tr>
			<td align="center" class="loginError" t="errorModalMsg:innerHTML">
			</td>
		</tr>
	</table>
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
		verify: {
			userName: "",
			passwordHash: ""
		},
		login() {

			Login(at.verify)
				.then(d => {
					console.log("here1");
					console.log(d);
					if (d.IsSuccess != undefined && !d.IsSuccess) {
						
					}
				})
				.catch(s => {
					console.log("here2");
					console.log(s);
				});
		},
		gotoRegister() {
			$.msgc.send("show register");
		},
		errorModal: undefined,
		errorModalMsg: "",
		beforeinit() {
			$.msgc.subscribe("show login", function () {
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

$.comp("login", o);