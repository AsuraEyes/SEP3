//
// This file was generated by the JavaTM Architecture for XML Binding(JAXB) Reference Implementation, v2.3.2 
// See <a href="https://javaee.github.io/jaxb-v2/">https://javaee.github.io/jaxb-v2/</a> 
// Any modifications to this file will be lost upon recompilation of the source schema. 
// Generated on: 2021.12.06 at 05:21:40 PM CET 
//


package io.spring.guides.gs_producing_web_service;

import java.util.ArrayList;
import java.util.List;
import javax.xml.bind.annotation.XmlAccessType;
import javax.xml.bind.annotation.XmlAccessorType;
import javax.xml.bind.annotation.XmlElement;
import javax.xml.bind.annotation.XmlRootElement;
import javax.xml.bind.annotation.XmlType;


/**
 * <p>Java class for anonymous complex type.
 * 
 * <p>The following schema fragment specifies the expected content contained within this class.
 * 
 * <pre>
 * &lt;complexType&gt;
 *   &lt;complexContent&gt;
 *     &lt;restriction base="{http://www.w3.org/2001/XMLSchema}anyType"&gt;
 *       &lt;sequence&gt;
 *         &lt;element name="MonthlyFee" type="{http://spring.io/guides/gs-producing-web-service}MonthlyFee"/&gt;
 *         &lt;element name="MonthlyFeeList" type="{http://spring.io/guides/gs-producing-web-service}MonthlyFee" maxOccurs="unbounded"/&gt;
 *       &lt;/sequence&gt;
 *     &lt;/restriction&gt;
 *   &lt;/complexContent&gt;
 * &lt;/complexType&gt;
 * </pre>
 * 
 * 
 */
@XmlAccessorType(XmlAccessType.FIELD)
@XmlType(name = "", propOrder = {
    "monthlyFee",
    "monthlyFeeList"
})
@XmlRootElement(name = "SOAPMonthlyFeeResponse")
public class SOAPMonthlyFeeResponse {

    @XmlElement(name = "MonthlyFee", required = true)
    protected MonthlyFee monthlyFee;
    @XmlElement(name = "MonthlyFeeList", required = true)
    protected List<MonthlyFee> monthlyFeeList;

    /**
     * Gets the value of the monthlyFee property.
     * 
     * @return
     *     possible object is
     *     {@link MonthlyFee }
     *     
     */
    public MonthlyFee getMonthlyFee() {
        return monthlyFee;
    }

    /**
     * Sets the value of the monthlyFee property.
     * 
     * @param value
     *     allowed object is
     *     {@link MonthlyFee }
     *     
     */
    public void setMonthlyFee(MonthlyFee value) {
        this.monthlyFee = value;
    }

    /**
     * Gets the value of the monthlyFeeList property.
     * 
     * <p>
     * This accessor method returns a reference to the live list,
     * not a snapshot. Therefore any modification you make to the
     * returned list will be present inside the JAXB object.
     * This is why there is not a <CODE>set</CODE> method for the monthlyFeeList property.
     * 
     * <p>
     * For example, to add a new item, do as follows:
     * <pre>
     *    getMonthlyFeeList().add(newItem);
     * </pre>
     * 
     * 
     * <p>
     * Objects of the following type(s) are allowed in the list
     * {@link MonthlyFee }
     * 
     * 
     */
    public List<MonthlyFee> getMonthlyFeeList() {
        if (monthlyFeeList == null) {
            monthlyFeeList = new ArrayList<MonthlyFee>();
        }
        return this.monthlyFeeList;
    }

}
