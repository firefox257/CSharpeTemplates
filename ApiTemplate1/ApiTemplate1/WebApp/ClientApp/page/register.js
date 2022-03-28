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
					<input type="text" tke="onchange" tr="user.FirstName:value"></input>
				</td>
			</tr>
			<tr>
				<td align="right">
					Last Name:
				</td>
				<td>
					<input type="text" tke="onchange" tr="user.LastName:value"></input>
				</td>
			</tr>
			<tr>
				<td align="right">
					Email:
				</td>
				<td>
					<input type="text" tke="onchange" tr="user.Email:value"></input>
				</td>
			</tr>
			<tr>
				<td align="right">
					Password:
				</td>
				<td>
					<input type="password" tke="onchange" tr="user.PasswordHash:value"></input>
				</td>
			</tr>
			<tr>
				<td >
					<c tt="button" te="create:onclick">Create</c>
				</td>
			</tr>
		</table>
	</span>
`;

var countId = 0;
function o() {
	var at =
	{
		attr:
		{
			get show() {
				return at.display != "none";
			}
			set show(v) {
				
			}
		},
		id: countId++,
		display: "none",
		user: {
			FirstName: "",
			LastName: "",
			Email: "",
			PasswordHash: ""
		},
		create() {
			console.log("user");
			console.log(at.user);
		},
		beforeinit() {
			$.msgc.subscribe()
		},
		init() {

		}
	};
	return at;
}
o.css = css;
o.html = html;

$.comp("register", o);