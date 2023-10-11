var css = `

`;
var html = `
	<div t="display:style.display" ti>
	</div>
`;
var countId = 0;
function o() {
	var at =
	{
		attr:
		{
			get show() {
				return at.display != "none";
			},
			set show(v) {
				if (v) {
					$.msgc.send("show page", at.id);
				}
				else {
					at.display = "none";
				}
			}

		},
		id: countId++,
		display: "none",
		beforeinit() {
			$.msgc.subscribe("show page", function(id)
			{
				if (id != at.id) {
					at.display = "none";
				}
				else {
					at.display = "block";
				}
			});
		},
		init() {

		}
	};
	return at;
}
o.css = css;
o.html = html;
$.comp("page", o);