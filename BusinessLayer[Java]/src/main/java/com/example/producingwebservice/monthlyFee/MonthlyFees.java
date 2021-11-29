package com.example.producingwebservice.monthlyFee;

import io.spring.guides.gs_producing_web_service.MonthlyFee;

import java.text.ParseException;

public interface MonthlyFees
{
    MonthlyFee getMonthlyFee(String username);
    MonthlyFee create(MonthlyFee monthlyFee) throws ParseException;
}
