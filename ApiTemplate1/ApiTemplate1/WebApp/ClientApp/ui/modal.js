var css = `
.modal
{
	position: absolute;
	top: 50vh;
	left: 50vw;
	transform: translate(-50%, -50%);
	border: 1px solid #000;
	background-color: #fff;
	border-radius: 3mm;
	padding: 2mm;
	display: inline-block;
}
`;
var html = `
<span class="modal" t="display:style.display" tgt="modals" ti></span>
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
					
					$.msgc.send("show modal background");
					$.msgc.send("show modal", at.id);
				}
				else {
					at.display = "inline-block";
					$.msgc.send("hide modal background");
				}
			}
		},
		id: countId++,
		display: "none",
		beforeinit()
		{
			$.msgc.subscribe("show modal", function (id) {
				if (id != at.id) {
					at.display = "none";
				}
				else {
					console.log("at here1");
					at.display = "inline-block";
				}
			});
		}
	};
	return at;
}
o.css = css;
o.html = html;
$.comp("modal", o);