<?xml version="1.0"?>
<xsl:stylesheet xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
                version="1.0">
<xsl:output method="text"/>
<xsl:template match="/">
          <xsl:for-each select="member/phone">
            <xsl:value-of select="@type"/>
            <xsl:text>:</xsl:text>
            <xsl:value-of select="."/>
            <xsl:text> </xsl:text>
         </xsl:for-each>
    </xsl:template>
</xsl:stylesheet>

