<%@ Control Language="c#" %>
	<span class="label">Company name:</span>
	<asp:TextBox ID="textCompanyName" Runat="server" Columns="50" width="200px"></asp:TextBox>
	<br />
	<span class="label">Address:</span>
	<asp:TextBox ID="textCompanyAddress" Runat="server" Columns="50" Rows="4" TextMode="MultiLine"
		width="202px"></asp:TextBox>
	<br />
	<span class="label">Contact person:</span>
	<asp:TextBox ID="textContactPerson" Runat="server" Columns="50" width="200px"></asp:TextBox>
	<br />
	<span class="label">Position held:</span>
	<asp:TextBox ID="textPosition" Runat="server" Columns="50" width="200px"></asp:TextBox>
	<br />
	<span class="label">Start date:</span>
	<asp:DropDownList ID="listStartDateMonth" Runat="server">
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
	<asp:DropDownList ID="listStartDateYear" Runat="server">
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
	<span class="label">End date:</span>
	<asp:DropDownList ID="listEndDateMonth" Runat="server">
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
	<asp:DropDownList ID="listEndDateYear" Runat="server">
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
	<span class="label">Responsibilities:</span>
	<asp:TextBox ID="textResponsibilities" Runat="server" Columns="50" Rows="5" TextMode="MultiLine"
		width="202px"></asp:TextBox>
	<br />
	<span class="label">Projects Worked on:</span>
	<asp:TextBox ID="textProjects" Runat="server" Columns="50" Rows="5" TextMode="MultiLine" width="202px"></asp:TextBox>
	<br />
