-- phpMyAdmin SQL Dump
-- version 5.0.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Apr 03, 2020 at 07:36 PM
-- Server version: 10.4.11-MariaDB
-- PHP Version: 7.4.3

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `assignment-04`
--

-- --------------------------------------------------------

--
-- Table structure for table `customer`
--

CREATE TABLE `customer` (
  `CustID` int(11) NOT NULL,
  `Title` text DEFAULT NULL,
  `Forename` text DEFAULT NULL,
  `Surname` text DEFAULT NULL,
  `Mobile` varchar(255) DEFAULT NULL,
  `Email_Address` varchar(255) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `customer`
--

INSERT INTO `customer` (`CustID`, `Title`, `Forename`, `Surname`, `Mobile`, `Email_Address`) VALUES
(1, 'Ms', 'Niamh', 'Dunne', '1233675332', 'ndunne4@mail.com'),
(2, 'Mx', 'Owen', 'Clarke', '1234934776', 'owenc26@mail.com'),
(4, 'Ms', 'Lauren', 'Casey', '1232574335', 'lauren.casey@mail.com'),
(5, 'Miss', 'Michaela', 'Byrne', '1232938662', 'byrne.michaela@mail.com'),
(6, 'Dr', 'James', 'Malone', '1233424664', 'j.malone22@mail.com');

-- --------------------------------------------------------

--
-- Table structure for table `homeaddress`
--

CREATE TABLE `homeaddress` (
  `AddressID` int(11) NOT NULL,
  `AddressLine1` varchar(255) DEFAULT NULL,
  `AddressLine2` varchar(255) DEFAULT NULL,
  `Town` text DEFAULT NULL,
  `CountyCity` text DEFAULT NULL,
  `Eircode` varchar(255) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `homeaddress`
--

INSERT INTO `homeaddress` (`AddressID`, `AddressLine1`, `AddressLine2`, `Town`, `CountyCity`, `Eircode`) VALUES
(1, '93 Abbeypark', 'Ballyfield', 'Naas', 'Kildare', 'W11 BK35'),
(2, '28 Grangeview', 'Parkwest', 'Finglas', 'Dublin', 'D17 HK85'),
(4, '49 Greenway', 'Ballinafad', 'Maynooth', 'Kildare', 'W45 BK35'),
(5, '35 Loughnaree', 'Vartry Valley', 'Wicklow', 'Wicklow', 'W76 EP18'),
(6, '6 Citypark', 'Citywest', 'Clondalkin', 'Dublin', 'D44 MR76');

-- --------------------------------------------------------

--
-- Table structure for table `shippingaddress`
--

CREATE TABLE `shippingaddress` (
  `AddressID` int(11) NOT NULL,
  `AddressLine1` varchar(255) DEFAULT NULL,
  `AddressLine2` varchar(255) DEFAULT NULL,
  `Town` text DEFAULT NULL,
  `CountyCity` text DEFAULT NULL,
  `Eircode` varchar(255) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `shippingaddress`
--

INSERT INTO `shippingaddress` (`AddressID`, `AddressLine1`, `AddressLine2`, `Town`, `CountyCity`, `Eircode`) VALUES
(1, '93 Abbeypark', 'Ballyfield', 'Naas', 'Kildare', 'W11 BK35'),
(2, '28 Grangeview', 'Parkwest', 'Finglas', 'Dublin', 'D17 HK85'),
(4, '49 Greenway', 'Ballinafad', 'Maynooth', 'Kildare', 'W45 BK35'),
(5, '35 Loughnaree', 'Vartry Valley', 'Wicklow', 'Wicklow', 'W76 EP18'),
(6, '6 Citypark', 'Citywest', 'Clondalkin', 'Dublin', 'D44 MR76');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `customer`
--
ALTER TABLE `customer`
  ADD PRIMARY KEY (`CustID`);

--
-- Indexes for table `homeaddress`
--
ALTER TABLE `homeaddress`
  ADD PRIMARY KEY (`AddressID`);

--
-- Indexes for table `shippingaddress`
--
ALTER TABLE `shippingaddress`
  ADD PRIMARY KEY (`AddressID`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `customer`
--
ALTER TABLE `customer`
  MODIFY `CustID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=7;

--
-- AUTO_INCREMENT for table `homeaddress`
--
ALTER TABLE `homeaddress`
  MODIFY `AddressID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=7;

--
-- AUTO_INCREMENT for table `shippingaddress`
--
ALTER TABLE `shippingaddress`
  MODIFY `AddressID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=7;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
