var css = `
.linkButton
{
	color: #00f;
	text-decoration: underline;
	cursor: pointer;
	-webkit-user-select: none;  /* Chrome all / Safari all */
	-moz-user-select: none;     /* Firefox all */
	-ms-user-select: none;      /* IE 10+ */
	user-select: none;
}
`;
var html = `
	<span class="linkButton" t="onclick:onclick" ti></span>
`;

function o() {
	var at =
	{
		attr:
		{
			onclick: undefined
		},
		onclick(e) {
			if (at.attr.onclick) at.attr.onclick(e);
		},
		init() {

		}
	};
	return at;
}
o.css = css;
o.html = html;
$.comp("linkButton", o);