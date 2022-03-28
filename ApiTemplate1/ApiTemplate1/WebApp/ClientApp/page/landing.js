var css = `
`;
var html = `

<c tt="register" to="registerPage"></c>
<c tt="login" to="loginPage"></c>

<c tt="modals"></c>
`;

function o() {
	var at =
	{
		attr:
		{

		},
		registerPage: undefined,
		loginPage: undefined,
		init()
		{
			
			at.registerPage.show = 1;

		}
	};
	return at;
}
o.css = css;
o.html = html;

$.comp("landing", o);