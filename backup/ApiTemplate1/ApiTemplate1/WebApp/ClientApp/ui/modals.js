var css = `
.modals
{
	position: absolute;
	top: 0;
	left: 0;
	right: 0;
	bottom: 0;
	width: 100%;
	height: 100%;
	z-index:1000;
	display: none;
	background-color: rgba(0, 0, 0, 0.8);
}

`;
var html = `
	<span class = "modals" t="display:style.display" tg="modals"></span>
`;

function o() {
	var at =
	{
		attr:
		{

		},
		display: "none",
		beforeinit()
		{
			
			$.msgc.subscribe("show modal background", function () {
				at.display = "inline-block";
			});
			$.msgc.subscribe("hide modal background", function(){
				at.display = "none";
			});
		}
	};
	return at;
}
o.css = css;
o.html = html;
$.comp("modals", o);