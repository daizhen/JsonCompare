<?xml version="1.0" encoding="UTF-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:fo="http://www.w3.org/1999/XSL/Format"
  xmlns:msxsl="urn:schemas-microsoft-com:xslt"
xmlns:myNS="urn:myNameSpace">
  <msxsl:script language="c#" implements-prefix="myNS">
    <msxsl:assembly name="JsonCompareLib"/>
    <msxsl:using namespace="JsonCompareLib"/>
    <![CDATA[
public string Diff(string originalText, string newText)
{
  return new LineDiff().CreateDiffHtml(originalText,newText);
}

]]>

  </msxsl:script>

  <xsl:template match="/descriptor">
    <html>
      <head>
        <title>Diff of SM Process</title>
      </head>
      <body>
        <div>
           <b>Process:</b><br/>
            <xsl:value-of  disable-output-escaping="yes" select="myNS:Diff(process/OriginalValue,process/NewValue)"/>
          <b>Init Expression:</b><br/>
          <div>
            <xsl:for-each select="pre.expressions/pre.expressions">
              <xsl:value-of  disable-output-escaping="yes" select="myNS:Diff(OriginalValue,NewValue)"/>
            </xsl:for-each>
          </div>

          <b>RAD calls:</b><br/>
          <div>
            <xsl:for-each select="rad/rad">
              RAD:<br/>
              <xsl:value-of  disable-output-escaping="yes" select="myNS:Diff(application/OriginalValue,application/NewValue)"/>
              Pre-Expression:<br/>
              <xsl:for-each select="pre.rad.expressions/pre.rad.expressions">
                <xsl:value-of  disable-output-escaping="yes" select="myNS:Diff(OriginalValue,NewValue)"/>
              </xsl:for-each>

              Param Names:<br/>
              <xsl:for-each select="names/names">
                <xsl:value-of  disable-output-escaping="yes" select="myNS:Diff(OriginalValue,NewValue)"/>
              </xsl:for-each>
              Param Values:<br/>
              <xsl:for-each select="values/values">
                <xsl:value-of  disable-output-escaping="yes" select="myNS:Diff(OriginalValue,NewValue)"/>
              </xsl:for-each>

              Post-Expression:<br/>
              <xsl:for-each select="post.rad.expressions/post.rad.expressions">
                <xsl:value-of  disable-output-escaping="yes" select="myNS:Diff(OriginalValue,NewValue)"/>
              </xsl:for-each>
            </xsl:for-each>
          </div>
        </div>

      </body>
    </html>
  </xsl:template>
</xsl:stylesheet>