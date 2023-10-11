var css = `

`;
var html = `
<c tt="page" to="page">
	
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
	
		beforeinit() {
			$.msgc.subscribe("show pageBase", function () {
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

$.comp("pageBase", o);