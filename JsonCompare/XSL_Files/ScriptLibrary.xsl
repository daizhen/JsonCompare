<?xml version="1.0" encoding="UTF-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:fo="http://www.w3.org/1999/XSL/Format"
  xmlns:msxsl="urn:schemas-microsoft-com:xslt"
xmlns:myNS="urn:myNameSpace">
  <msxsl:script language="c#" implements-prefix="myNS">

    <![CDATA[

public string trans(string s)
{
  return "<b>"+s+" ....====</b>";
}
public string Diff(string originalText, string newText)
{
  return originalText + "<br/>"+newText;
}

]]>

  </msxsl:script>

  <xsl:template match="/descriptor">
    <html>
      <head>
        <title>Diff of SM ScriptLibrary</title>
      </head>
      <body>
        <div>
          Name:<br/>
          <xsl:value-of  disable-output-escaping="yes" select="myNS:Diff(name/OriginalValue,name/NewValue)"/>
        </div>
        <div>
          Package:<br/>
          <xsl:value-of  disable-output-escaping="yes" select="myNS:Diff(package/OriginalValue,package/NewValue)"/>
        </div>
        <div>
          Script:<br/>
          <xsl:value-of  disable-output-escaping="yes" select="myNS:Diff(script/OriginalValue,script/NewValue)"/>
        </div>
      </body>
    </html>
  </xsl:template>
</xsl:stylesheet>