<%@ Control Language="c#" %>

	<span class="label">Education Type:</span>
	<asp:DropDownList ID="listEducationType" Runat="server" width="206px">
		<asp:ListItem>High School</asp:ListItem>
		<asp:ListItem>2 Year College</asp:ListItem>
		<asp:ListItem>Bachelors</asp:ListItem>
		<asp:ListItem>Masters</asp:ListItem>
		<asp:ListItem>PHD</asp:ListItem>
	</asp:DropDownList>
	<br />
	<span class="label">Name:</span>
	<asp:TextBox ID="textSchoolName" Runat="server" Columns="50" width="200px"></asp:TextBox>
	<br />
	<span class="label">Address:</span>
	<asp:TextBox ID="textSchoolAddress" Runat="server" Columns="50" Rows="4" TextMode="MultiLine"
		width="202px"></asp:TextBox>
	<br />
	<span class="label">Graduation Year:</span>
	<asp:DropDownList ID="listGraduationYear" Runat="server" width="206px">
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
	<span class="label">Major Field Of study:</span>
	<asp:ListBox ID="listMajor" Runat="server" SelectionMode="Multiple" width="206px">
		<asp:ListItem>Business Administration</asp:ListItem>
		<asp:ListItem>Computer Science</asp:ListItem>
		<asp:ListItem>Political Science</asp:ListItem>
	</asp:ListBox>
	<br />
	<span class="label">Minor Field of study:</span>
	<asp:ListBox ID="listMinor" Runat="server" SelectionMode="Multiple" width="206px">
		<asp:ListItem>Business Administration</asp:ListItem>
		<asp:ListItem>Computer Science</asp:ListItem>
		<asp:ListItem>Political Science</asp:ListItem>
	</asp:ListBox>
	<br />
