<%@ Control Language="c#" %>
	<span class="label">Title:</span>
	<asp:DropDownList ID="listTitle" Runat="server" width="143px">
		<asp:ListItem>Mr.</asp:ListItem>
		<asp:ListItem>Mrs.</asp:ListItem>
		<asp:ListItem>Miss</asp:ListItem>
		<asp:ListItem>Ms.</asp:ListItem>
	</asp:DropDownList>
	<br />
	<span class="label">First Name:</span>
	<asp:TextBox ID="textFirstName" Runat="server" Columns="50" width="200px"></asp:TextBox>
	<asp:RequiredFieldValidator Runat="server" ErrorMessage="First Name is required" ID="validatorFirstName" Display="Dynamic"
		ControlToValidate="textFirstName">*</asp:RequiredFieldValidator>
	<br />
	<span class="label">Second Name:</span>
	<asp:TextBox ID="textSecondName" Runat="server" Columns="50" width="200px"></asp:TextBox>
	<asp:RequiredFieldValidator Runat="server" ErrorMessage="Second Name is required" ID="validatorSecondName" Display="Dynamic"
		ControlToValidate="textSecondName">*</asp:RequiredFieldValidator>
	<br />
	<span class="label">E-mail:</span>
	<asp:TextBox ID="textEmail" Runat="server" Columns="50" width="200px"></asp:TextBox>
	<asp:RegularExpressionValidator Runat="server" ErrorMessage="Invalid E-mail Address" ID="validatorRegEmail" Display="Dynamic"
		ControlToValidate="textEmail" ValidationExpression=".+@.+\.[a-z]+">*</asp:RegularExpressionValidator>
	<br />
	<span class="label">Street Address:</span>
	<asp:TextBox ID="textStreetAddress" Runat="server" TextMode="MultiLine" Columns="50" Rows="4"
		width="202px"></asp:TextBox>
	<br />
	<span class="label">Country:</span>
	<asp:DropDownList id="comboCountry" runat="server" width="206px"></asp:DropDownList>
	<br />
	<span class="label">Nationality:</span>
	<asp:DropDownList id="comboNationality" runat="server" width="206px"></asp:DropDownList>
	<br />
	<span class="label">Birthdate:</span>
	<asp:DropDownList ID="listMonth" Runat="server">
		<asp:ListItem>1</asp:ListItem>
		<asp:ListItem>2</asp:ListItem>
		<asp:ListItem>3</asp:ListItem>
		<asp:ListItem>4</asp:ListItem>
		<asp:ListItem>5</asp:ListItem>
		<asp:ListItem>6</asp:ListItem>
		<asp:ListItem>7</asp:ListItem>
		<asp:ListItem>8</asp:ListItem>
		<asp:ListItem>9</asp:ListItem>
		<asp:ListItem>10</asp:ListItem>
		<asp:ListItem>11</asp:ListItem>
		<asp:ListItem>12</asp:ListItem>
	</asp:DropDownList>
	<asp:DropDownList ID="listDay" Runat="server">
		<asp:ListItem>1</asp:ListItem>
		<asp:ListItem>2</asp:ListItem>
		<asp:ListItem>3</asp:ListItem>
		<asp:ListItem>4</asp:ListItem>
		<asp:ListItem>5</asp:ListItem>
		<asp:ListItem>6</asp:ListItem>
		<asp:ListItem>7</asp:ListItem>
		<asp:ListItem>8</asp:ListItem>
		<asp:ListItem>9</asp:ListItem>
		<asp:ListItem>10</asp:ListItem>
		<asp:ListItem>11</asp:ListItem>
		<asp:ListItem>12</asp:ListItem>
		<asp:ListItem>13</asp:ListItem>
		<asp:ListItem>14</asp:ListItem>
		<asp:ListItem>15</asp:ListItem>
		<asp:ListItem>16</asp:ListItem>
		<asp:ListItem>17</asp:ListItem>
		<asp:ListItem>18</asp:ListItem>
		<asp:ListItem>19</asp:ListItem>
		<asp:ListItem>20</asp:ListItem>
		<asp:ListItem>21</asp:ListItem>
		<asp:ListItem>22</asp:ListItem>
		<asp:ListItem>23</asp:ListItem>
		<asp:ListItem>24</asp:ListItem>
		<asp:ListItem>25</asp:ListItem>
		<asp:ListItem>26</asp:ListItem>
		<asp:ListItem>27</asp:ListItem>
		<asp:ListItem>28</asp:ListItem>
		<asp:ListItem>29</asp:ListItem>
		<asp:ListItem>30</asp:ListItem>
		<asp:ListItem>31</asp:ListItem>
	</asp:DropDownList>
	<asp:DropDownList ID="listYear" Runat="server">
		<asp:ListItem>2005</asp:ListItem>
		<asp:ListItem>2004</asp:ListItem>
		<asp:ListItem>2003</asp:ListItem>
		<asp:ListItem>2002</asp:ListItem>
		<asp:ListItem>2001</asp:ListItem>
		<asp:ListItem>2000</asp:ListItem>
		<asp:ListItem>1999</asp:ListItem>
		<asp:ListItem>1998</asp:ListItem>
		<asp:ListItem>1997</asp:ListItem>
		<asp:ListItem>1996</asp:ListItem>
		<asp:ListItem>1995</asp:ListItem>
		<asp:ListItem>1994</asp:ListItem>
		<asp:ListItem>1993</asp:ListItem>
		<asp:ListItem>1992</asp:ListItem>
		<asp:ListItem>1991</asp:ListItem>
		<asp:ListItem>1990</asp:ListItem>
		<asp:ListItem>1989</asp:ListItem>
		<asp:ListItem>1988</asp:ListItem>
		<asp:ListItem>1987</asp:ListItem>
		<asp:ListItem>1986</asp:ListItem>
		<asp:ListItem>1985</asp:ListItem>
		<asp:ListItem>1984</asp:ListItem>
		<asp:ListItem>1983</asp:ListItem>
		<asp:ListItem>1982</asp:ListItem>
		<asp:ListItem>1981</asp:ListItem>
		<asp:ListItem>1980</asp:ListItem>
		<asp:ListItem>1979</asp:ListItem>
		<asp:ListItem>1978</asp:ListItem>
		<asp:ListItem>1977</asp:ListItem>
		<asp:ListItem>1976</asp:ListItem>
		<asp:ListItem>1975</asp:ListItem>
		<asp:ListItem>1974</asp:ListItem>
		<asp:ListItem>1973</asp:ListItem>
		<asp:ListItem>1972</asp:ListItem>
		<asp:ListItem>1971</asp:ListItem>
		<asp:ListItem>1970</asp:ListItem>
		<asp:ListItem>1969</asp:ListItem>
		<asp:ListItem>1968</asp:ListItem>
		<asp:ListItem>1967</asp:ListItem>
		<asp:ListItem>1966</asp:ListItem>
		<asp:ListItem>1965</asp:ListItem>
		<asp:ListItem>1964</asp:ListItem>
		<asp:ListItem>1963</asp:ListItem>
		<asp:ListItem>1962</asp:ListItem>
		<asp:ListItem>1961</asp:ListItem>
		<asp:ListItem>1960</asp:ListItem>
	</asp:DropDownList>
	<br />
	<span class="label">Marital Status:</span>
	<asp:RadioButtonList ID="radioMartial" Runat="server" CssClass="radioInputs">
		<asp:ListItem Selected="True">single</asp:ListItem>
		<asp:ListItem>married</asp:ListItem>
	</asp:RadioButtonList>
	<asp:CheckBox ID="checkTerms" Text="I agree to the Terms &amp; Conditions" Runat="server"></asp:CheckBox>
	<asp:CustomValidator runat="server" ErrorMessage="You must agree to the terms!" ClientValidationFunction="ClientValidation" ID="Customvalidator1">*</asp:CustomValidator>
	<br />
	<asp:ValidationSummary ID="valSummary" Runat="server" DisplayMode="BulletList"></asp:ValidationSummary>
<script type="text/javascript">
function ClientValidation(source, args)
{
     args.IsValid = document.getElementById("<%= checkTerms.ClientID %>").checked;
}
</script>