var css = `
`;
var html = `

<c tt="register" to="registerPage"></c>
<c tt="login" to="loginPage"></c>
<c tt="main" to="mainPage"></c>

<c tt="modals"></c>
<c tt="errorModal"></c>
`;

function o() {
	var at =
	{
		attr:
		{

		},
		registerPage: undefined,
		loginPage: undefined,
		mainPage: undefined,
		init()
		{
			
			at.loginPage.show = 1;

		}
	};
	return at;
}
o.css = css;
o.html = html;

$.comp("landing", o);