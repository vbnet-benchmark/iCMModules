<%@ Import Namespace="Telerik.QuickStart" %>
<%@ Register TagPrefix="help" TagName="Control" Src="ControlHelp.ascx" %>
<%@ Control Language="c#" AutoEventWireup="false" TargetSchema="http://schemas.microsoft.com/intellisense/ie5" %>
<div id="1" class="text">
    The distribution file (EXE) is shipped with a "<b>Deployment Manual and Reference</b>" 
    in MS Help 2 format, which is registered in the MSDN during the installation.
    
    The help is also available online at <a href="http://www.telerik.com/Help/">http://www.telerik.com/Help/</a>
    <p>
        <help:Control ID="controlHelp" Runat="server" />
    </p>
    For additional technical resources, please visit the <a href="http://www.telerik.com/<%= ProductInfo.RadControlName %>" target="_blank">
        r.a.d.<b><%= ProductInfo.ControlName %></b></a> product section and the <a href="http://www.telerik.com/support" target="_blank">
        support</a> section on our web-site.
</div>
<div id="2" class="text" style="DISPLAY:none">
    <b>t</b>elerik is devoted to delivering not only high quality software but also 
    the respective level of technical support that will guarantee your effortless 
    experience when evaluating, deploying, or customizing our products.
    <div style="MARGIN-TOP:20px;FONT-WEIGHT:bold;BORDER-BOTTOM:gray 1px dotted">
        Support resources
    </div>
    An array of on-line technical resources is available in the <a target="_blank" href="http://www.telerik.com/support">
        support section</a> of our web-site:
    <br/>
    &nbsp;&nbsp;• Integrated ticketing system with complete history<br/>
    &nbsp;&nbsp;• Knowledge base<br/>
    &nbsp;&nbsp;• Learning center with on-line videos<br/>
    &nbsp;&nbsp;• Customer forums<br/>
    &nbsp;&nbsp;• Tips and tricks<br/>
    &nbsp;&nbsp;• Frequently asked questions<br/>
    &nbsp;&nbsp;• Feature suggestion/bug reporting section
</div>
