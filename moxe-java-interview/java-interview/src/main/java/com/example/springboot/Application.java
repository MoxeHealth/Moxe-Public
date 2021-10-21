package com.example.springboot;

import com.example.springboot.controller.InitializeController;
import javax.annotation.PostConstruct;
import org.springframework.boot.SpringApplication;
import org.springframework.boot.autoconfigure.SpringBootApplication;

@SpringBootApplication
public class Application {

	public static void main(String[] args) {
		SpringApplication.run(Application.class, args);
	}
	@PostConstruct
	private void init() {
		System.out.println("Initialize databases");
		InitializeController initialize = new InitializeController();
		initialize.initialzeDatabase();
	}

}
