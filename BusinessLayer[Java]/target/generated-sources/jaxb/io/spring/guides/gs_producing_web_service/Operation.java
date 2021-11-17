//
// This file was generated by the JavaTM Architecture for XML Binding(JAXB) Reference Implementation, v2.3.2 
// See <a href="https://javaee.github.io/jaxb-v2/">https://javaee.github.io/jaxb-v2/</a> 
// Any modifications to this file will be lost upon recompilation of the source schema. 
// Generated on: 2021.11.16 at 03:50:12 PM CET 
//


package io.spring.guides.gs_producing_web_service;

import javax.xml.bind.annotation.XmlEnum;
import javax.xml.bind.annotation.XmlType;


/**
 * <p>Java class for Operation.
 * 
 * <p>The following schema fragment specifies the expected content contained within this class.
 * <p>
 * <pre>
 * &lt;simpleType name="Operation"&gt;
 *   &lt;restriction base="{http://www.w3.org/2001/XMLSchema}string"&gt;
 *     &lt;enumeration value="GET"/&gt;
 *     &lt;enumeration value="DELETE"/&gt;
 *     &lt;enumeration value="POST"/&gt;
 *     &lt;enumeration value="PATCH"/&gt;
 *     &lt;enumeration value="GETALL"/&gt;
 *   &lt;/restriction&gt;
 * &lt;/simpleType&gt;
 * </pre>
 * 
 */
@XmlType(name = "Operation")
@XmlEnum
public enum Operation {

    GET,
    DELETE,
    POST,
    PATCH,
    GETALL;

    public String value() {
        return name();
    }

    public static Operation fromValue(String v) {
        return valueOf(v);
    }

}
