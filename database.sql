CREATE TABLE `single_word` (
  `word_id` INT NOT NULL AUTO_INCREMENT,
  `word` VARCHAR(50) NOT NULL,
  `note` VARCHAR(100) NULL,
  PRIMARY KEY (`word_id`),
  UNIQUE INDEX `idsingle_word_UNIQUE` (`word_id` ASC))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;

CREATE TABLE `language` (
  `language_id` int(11) NOT NULL AUTO_INCREMENT,
  `language_name` varchar(50) NOT NULL,
  `description` varchar(100) DEFAULT NULL,
  PRIMARY KEY (`language_id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;


CREATE TABLE `ys_eng`.`translation` (
  `translation_id` INT NOT NULL AUTO_INCREMENT,
  `word_id` INT NOT NULL,
  `language_id` INT NOT NULL,
  `text` VARCHAR(45) NOT NULL,
  PRIMARY KEY (`translation_id`),
  INDEX `translation_word_fk_idx` (`word_id` ASC),
  INDEX `translation_language_fk_idx` (`language_id` ASC),
  CONSTRAINT `translation_word_fk`
    FOREIGN KEY (`word_id`)
    REFERENCES `ys_eng`.`single_word` (`word_id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `translation_language_fk`
    FOREIGN KEY (`language_id`)
    REFERENCES `ys_eng`.`language` (`language_id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION);
	
ALTER TABLE `ys_eng`.`translation` 
ADD COLUMN `priority` INT NOT NULL AFTER `text`;

	
CREATE TABLE `ys_eng`.`category` (
  `category_id` INT NOT NULL AUTO_INCREMENT,
  `category_name` VARCHAR(45) NOT NULL,
  `category_description` VARCHAR(255) NOT NULL,
  `category_image` VARCHAR(255) NULL,
  PRIMARY KEY (`category_id`));
  
  
  CREATE TABLE `ys_eng`.`word_category` (
  `word_category_id` INT NOT NULL AUTO_INCREMENT,
  `word_id` INT NOT NULL,
  `category_id` INT NOT NULL,
  `note` VARCHAR(100) NULL,
  PRIMARY KEY (`word_category_id`),
  INDEX `word_category_fk_idx` (`word_id` ASC),
  INDEX `category_fk_idx` (`category_id` ASC),
  CONSTRAINT `word_category_fk`
    FOREIGN KEY (`word_id`)
    REFERENCES `ys_eng`.`single_word` (`word_id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `category_fk`
    FOREIGN KEY (`category_id`)
    REFERENCES `ys_eng`.`category` (`category_id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION);
	
CREATE TABLE `ys_eng`.`level` (
  `level_id` INT NOT NULL AUTO_INCREMENT,
  `level_name` VARCHAR(45) NOT NULL,
  `description` VARCHAR(45) NULL,
  PRIMARY KEY (`level_id`));

CREATE TABLE `ys_eng`.`word_meaning` (
  `meaning_id` INT NOT NULL AUTO_INCREMENT,
  `word_id` INT NOT NULL,
  `language_id` INT NOT NULL,
  `text` TEXT(255) NOT NULL,
  PRIMARY KEY (`meaning_id`),
  INDEX `meaning_word_fk_idx` (`word_id` ASC),
  INDEX `meaning_language_fk_idx` (`language_id` ASC),
  CONSTRAINT `meaning_word_fk`
    FOREIGN KEY (`word_id`)
    REFERENCES `ys_eng`.`single_word` (`word_id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `meaning_language_fk`
    FOREIGN KEY (`language_id`)
    REFERENCES `ys_eng`.`language` (`language_id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION);

	
	CREATE TABLE `ys_eng`.`synonim` (
  `synonim_id` INT NOT NULL AUTO_INCREMENT,
  `word1_id` INT NOT NULL,
  `word2_id` INT NOT NULL,
  PRIMARY KEY (`synonim_id`),
  INDEX `word1_fk_idx` (`word1_id` ASC),
  INDEX `word2_fk_idx` (`word2_id` ASC),
  CONSTRAINT `word1_fk`
    FOREIGN KEY (`word1_id`)
    REFERENCES `ys_eng`.`single_word` (`word_id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `word2_fk`
    FOREIGN KEY (`word2_id`)
    REFERENCES `ys_eng`.`single_word` (`word_id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION);
	
	CREATE TABLE `ys_eng`.`word_image` (
  `image_id` INT NOT NULL AUTO_INCREMENT,
  `word_id` INT NOT NULL,
  `image_url` VARCHAR(255) NOT NULL,
  PRIMARY KEY (`image_id`),
  INDEX `image_word_fk_idx` (`word_id` ASC),
  CONSTRAINT `image_word_fk`
    FOREIGN KEY (`word_id`)
    REFERENCES `ys_eng`.`single_word` (`word_id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION);
	
	
CREATE TABLE `ys_eng`.`sentence` (
  `sentence_id` INT NOT NULL AUTO_INCREMENT,
  `sentence_text` TEXT(255) NOT NULL,
  `sentence_level` INT NOT NULL,
  PRIMARY KEY (`sentence_id`),
  INDEX `sentence_level_fk_idx` (`sentence_level` ASC),
  CONSTRAINT `sentence_level_fk`
    FOREIGN KEY (`sentence_level`)
    REFERENCES `ys_eng`.`level` (`level_id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION);

CREATE TABLE `ys_eng`.`sentence_words` (
  `sentence_word_id` INT NOT NULL AUTO_INCREMENT,
  `sentence_id` INT NOT NULL,
  `word_id` INT NOT NULL,
  `priority` INT NULL,
  PRIMARY KEY (`sentence_word_id`),
  INDEX `sentence_fk_idx` (`sentence_id` ASC),
  INDEX `word_fk_idx` (`word_id` ASC),
  CONSTRAINT `sentence_fk`
    FOREIGN KEY (`sentence_id`)
    REFERENCES `ys_eng`.`sentence` (`sentence_id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `word_fk`
    FOREIGN KEY (`word_id`)
    REFERENCES `ys_eng`.`single_word` (`word_id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION);


