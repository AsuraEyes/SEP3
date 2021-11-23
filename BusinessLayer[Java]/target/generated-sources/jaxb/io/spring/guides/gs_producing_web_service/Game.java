//
// This file was generated by the JavaTM Architecture for XML Binding(JAXB) Reference Implementation, v2.3.2 
// See <a href="https://javaee.github.io/jaxb-v2/">https://javaee.github.io/jaxb-v2/</a> 
// Any modifications to this file will be lost upon recompilation of the source schema. 
// Generated on: 2021.11.23 at 11:50:23 AM CET 
//


package io.spring.guides.gs_producing_web_service;

import javax.xml.bind.annotation.XmlAccessType;
import javax.xml.bind.annotation.XmlAccessorType;
import javax.xml.bind.annotation.XmlElement;
import javax.xml.bind.annotation.XmlType;


/**
 * <p>Java class for Game complex type.
 * 
 * <p>The following schema fragment specifies the expected content contained within this class.
 * 
 * <pre>
 * &lt;complexType name="Game"&gt;
 *   &lt;complexContent&gt;
 *     &lt;restriction base="{http://www.w3.org/2001/XMLSchema}anyType"&gt;
 *       &lt;sequence&gt;
 *         &lt;element name="id" type="{http://www.w3.org/2001/XMLSchema}int"/&gt;
 *         &lt;element name="name" type="{http://www.w3.org/2001/XMLSchema}string"/&gt;
 *         &lt;element name="complexity" type="{http://www.w3.org/2001/XMLSchema}int"/&gt;
 *         &lt;element name="timeEstimation" type="{http://www.w3.org/2001/XMLSchema}int"/&gt;
 *         &lt;element name="minNumberOfPlayers" type="{http://www.w3.org/2001/XMLSchema}int"/&gt;
 *         &lt;element name="maxNumberOfPlayers" type="{http://www.w3.org/2001/XMLSchema}int"/&gt;
 *         &lt;element name="shortDescription" type="{http://www.w3.org/2001/XMLSchema}string"/&gt;
 *         &lt;element name="neededEquipment" type="{http://www.w3.org/2001/XMLSchema}string"/&gt;
 *         &lt;element name="minAge" type="{http://www.w3.org/2001/XMLSchema}int"/&gt;
 *         &lt;element name="maxAge" type="{http://www.w3.org/2001/XMLSchema}int"/&gt;
 *         &lt;element name="tutorial" type="{http://www.w3.org/2001/XMLSchema}string"/&gt;
 *         &lt;element name="approved" type="{http://www.w3.org/2001/XMLSchema}boolean"/&gt;
 *       &lt;/sequence&gt;
 *     &lt;/restriction&gt;
 *   &lt;/complexContent&gt;
 * &lt;/complexType&gt;
 * </pre>
 * 
 * 
 */
@XmlAccessorType(XmlAccessType.FIELD)
@XmlType(name = "Game", propOrder = {
    "id",
    "name",
    "complexity",
    "timeEstimation",
    "minNumberOfPlayers",
    "maxNumberOfPlayers",
    "shortDescription",
    "neededEquipment",
    "minAge",
    "maxAge",
    "tutorial",
    "approved"
})
public class Game {

    protected int id;
    @XmlElement(required = true)
    protected String name;
    protected int complexity;
    protected int timeEstimation;
    protected int minNumberOfPlayers;
    protected int maxNumberOfPlayers;
    @XmlElement(required = true)
    protected String shortDescription;
    @XmlElement(required = true)
    protected String neededEquipment;
    protected int minAge;
    protected int maxAge;
    @XmlElement(required = true)
    protected String tutorial;
    protected boolean approved;

    /**
     * Gets the value of the id property.
     * 
     */
    public int getId() {
        return id;
    }

    /**
     * Sets the value of the id property.
     * 
     */
    public void setId(int value) {
        this.id = value;
    }

    /**
     * Gets the value of the name property.
     * 
     * @return
     *     possible object is
     *     {@link String }
     *     
     */
    public String getName() {
        return name;
    }

    /**
     * Sets the value of the name property.
     * 
     * @param value
     *     allowed object is
     *     {@link String }
     *     
     */
    public void setName(String value) {
        this.name = value;
    }

    /**
     * Gets the value of the complexity property.
     * 
     */
    public int getComplexity() {
        return complexity;
    }

    /**
     * Sets the value of the complexity property.
     * 
     */
    public void setComplexity(int value) {
        this.complexity = value;
    }

    /**
     * Gets the value of the timeEstimation property.
     * 
     */
    public int getTimeEstimation() {
        return timeEstimation;
    }

    /**
     * Sets the value of the timeEstimation property.
     * 
     */
    public void setTimeEstimation(int value) {
        this.timeEstimation = value;
    }

    /**
     * Gets the value of the minNumberOfPlayers property.
     * 
     */
    public int getMinNumberOfPlayers() {
        return minNumberOfPlayers;
    }

    /**
     * Sets the value of the minNumberOfPlayers property.
     * 
     */
    public void setMinNumberOfPlayers(int value) {
        this.minNumberOfPlayers = value;
    }

    /**
     * Gets the value of the maxNumberOfPlayers property.
     * 
     */
    public int getMaxNumberOfPlayers() {
        return maxNumberOfPlayers;
    }

    /**
     * Sets the value of the maxNumberOfPlayers property.
     * 
     */
    public void setMaxNumberOfPlayers(int value) {
        this.maxNumberOfPlayers = value;
    }

    /**
     * Gets the value of the shortDescription property.
     * 
     * @return
     *     possible object is
     *     {@link String }
     *     
     */
    public String getShortDescription() {
        return shortDescription;
    }

    /**
     * Sets the value of the shortDescription property.
     * 
     * @param value
     *     allowed object is
     *     {@link String }
     *     
     */
    public void setShortDescription(String value) {
        this.shortDescription = value;
    }

    /**
     * Gets the value of the neededEquipment property.
     * 
     * @return
     *     possible object is
     *     {@link String }
     *     
     */
    public String getNeededEquipment() {
        return neededEquipment;
    }

    /**
     * Sets the value of the neededEquipment property.
     * 
     * @param value
     *     allowed object is
     *     {@link String }
     *     
     */
    public void setNeededEquipment(String value) {
        this.neededEquipment = value;
    }

    /**
     * Gets the value of the minAge property.
     * 
     */
    public int getMinAge() {
        return minAge;
    }

    /**
     * Sets the value of the minAge property.
     * 
     */
    public void setMinAge(int value) {
        this.minAge = value;
    }

    /**
     * Gets the value of the maxAge property.
     * 
     */
    public int getMaxAge() {
        return maxAge;
    }

    /**
     * Sets the value of the maxAge property.
     * 
     */
    public void setMaxAge(int value) {
        this.maxAge = value;
    }

    /**
     * Gets the value of the tutorial property.
     * 
     * @return
     *     possible object is
     *     {@link String }
     *     
     */
    public String getTutorial() {
        return tutorial;
    }

    /**
     * Sets the value of the tutorial property.
     * 
     * @param value
     *     allowed object is
     *     {@link String }
     *     
     */
    public void setTutorial(String value) {
        this.tutorial = value;
    }

    /**
     * Gets the value of the approved property.
     * 
     */
    public boolean isApproved() {
        return approved;
    }

    /**
     * Sets the value of the approved property.
     * 
     */
    public void setApproved(boolean value) {
        this.approved = value;
    }

}
