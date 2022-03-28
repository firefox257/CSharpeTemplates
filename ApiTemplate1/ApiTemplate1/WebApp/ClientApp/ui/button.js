var css = `
.button
{
	border:1px solid #000;
	border-radius: 2mm;
	display: inline-block;
	background-color: #fff;
	box-shadow: 1mm 1mm 2mm rgba(0, 0, 0, 0.6);
	padding: 0 1mm;
	-webkit-user-select: none;  /* Chrome all / Safari all */
	-moz-user-select: none;     /* Firefox all */
	-ms-user-select: none;      /* IE 10+ */
	user-select: none;
}
.button:active
{
	box-shadow: none;
}
`;

var html = `
	<span class ="button" te="onclick:onclick" ti></span>
`;

function o()
{
	var at =
	{
		attr:
		{
			onclick:undefined
		},
		onclick(e)
		{
			if (at.attr.onclick) at.attr.onclick(e);
		},
		init()
		{

		}
	};

	return at;
}
o.html = html;
o.css = css;

$.comp("button", o);
