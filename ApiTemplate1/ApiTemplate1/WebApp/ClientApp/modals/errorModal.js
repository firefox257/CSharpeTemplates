var css = `
.errorModalMsg
{
	color: #700;
}
`;
var html = `
<c tt="modal" to="modal">
	<table>
		<tr>
	</table>
</c>
`;

function o() {
	var at =
	{
		attr:
		{

		},
		modal:undefined,
		init() {

		}
	};
	return at;
}
o.css = css;
o.html = html;
$.comp("errorModal", o);