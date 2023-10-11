var css = `
.errorModalMsg
{
	color: #d00;
}
`;
var html = `
<c tt="modal" to="modal">
	<table>
		<tr>
			<td align="center">
				<h2 class="errorModalMsg">
					Error
				</h2>
			</td>
		</tr>
		<tr>
			<td align="center" class="errorModalMsg" t="msg:innerHTML">
				
			</td>
		</tr>
		<tr>
			<td align ="center">
				<c tt="button" te="close:onclick">Close</c>
			</td>
		</tr>
	</table>
</c>
`;

function o() {
	var at =
	{
		attr:
		{
			get show() {
				return at.modal.show;
			},
			set show(v) {
				at.modal.show = v;
			},
			get message() {
				return at.msg;
			},
			set message(v) {
				at.msg = v;
			}
		},
		modal: undefined,
		msg: "",
		callback: undefined,
		close() {
			at.modal.show = 0;
			if (at.callback) at.callback();
			at.callback = undefined;
		},
		beforeinit() {
			$.msgc.subscribe("show error modal", function (msg, callback) {
				at.attr.message = msg;
				at.attr.show = 1;
				at.callback = callback;
			});
		},
		init() {

		}
	};
	return at;
}
o.css = css;
o.html = html;
$.comp("errorModal", o);