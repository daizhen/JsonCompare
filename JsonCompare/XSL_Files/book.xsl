<?xml version="1.0" encoding="UTF-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:fo="http://www.w3.org/1999/XSL/Format">

  <xsl:template match="/">
    <html>
      <head>
        <title>BOOKS AT CYBERSHOPPE</title>
      </head>
      <body>
        <hi>BOOKS AT CYBERSHOPPE</hi>
        <table border="3" cellspacing="2" cellpadding="6">
          <thead align="center" BGCOLOR="SILVER">
            <th>BOOK ID</th>
            <th>TITILE</th>
            <th>RATE</th>
            <th>AUTHOR(S)</th>
          </thead>
          <tbody>
            <xsl:for-each select="BOOKS/BOOK">
              <tr>
                <td>
                  <font color="red">
                    <xsl:value-of select="@BOOKID"/>
                  </font>
                </td>
                <td>
                  <xsl:value-of select="TITLE"/>
                </td>
                <td>
                  <xsl:value-of select="RATE"/>
                </td>
                <td>
                  <xsl:apply-templates select="AUTHOR"/>
                </td>
              </tr>
            </xsl:for-each>
          </tbody>
        </table>
      </body>
    </html>
  </xsl:template>
</xsl:stylesheet>