<?xml version="1.0" encoding="UTF-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform" xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance">
<xsl:output version="1.0" encoding="utf-8" omit-xml-declaration="yes" indent="no" media-type="text/plain" />

<xsl:template match="*[@class='PageHeading']">
<xsl:apply-templates />
<xsl:if test="(text()!='')"> 
=================================================
</xsl:if>
</xsl:template>    

<xsl:template match="*[@class='SubHeading']">
<xsl:apply-templates />
<xsl:if test="(text()!='')">
-------------------------------------------------
</xsl:if>
</xsl:template>  

<xsl:template match="a">
<xsl:apply-templates /><xsl:text> </xsl:text><xsl:value-of select="@href" />
</xsl:template>
  
<xsl:template match="strong">
<xsl:if test="(text()!='')">
*<xsl:apply-templates />*
</xsl:if>
</xsl:template> 

<xsl:template match="div[@align='center']">
<xsl:text></xsl:text><xsl:apply-templates />        
</xsl:template>

<xsl:template match="br">
<xsl:text></xsl:text><xsl:apply-templates />        
</xsl:template>
    
<xsl:template match="div">
<xsl:apply-templates />
<xsl:text>
</xsl:text>        
</xsl:template>
       	
<xsl:template match="li">
<xsl:text>    *</xsl:text><xsl:apply-templates />
</xsl:template> 

<xsl:template match="ul">
<xsl:apply-templates />
<xsl:text>

</xsl:text>     
</xsl:template> 
   

</xsl:stylesheet>
