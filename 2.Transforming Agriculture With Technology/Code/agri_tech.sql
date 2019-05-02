-- phpMyAdmin SQL Dump
-- version 4.7.0
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Mar 28, 2019 at 06:28 AM
-- Server version: 10.1.26-MariaDB
-- PHP Version: 7.1.8

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `agri_tech`
--

-- --------------------------------------------------------

--
-- Table structure for table `booking`
--

CREATE TABLE `booking` (
  `farmer_id` varchar(255) NOT NULL,
  `id` int(10) NOT NULL,
  `transcation_key` varchar(200) NOT NULL,
  `cropname` varchar(255) NOT NULL,
  `capacity` varchar(255) NOT NULL,
  `date1` varchar(255) NOT NULL,
  `chamberid` varchar(255) NOT NULL,
  `status` varchar(100) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `booking`
--

INSERT INTO `booking` (`farmer_id`, `id`, `transcation_key`, `cropname`, `capacity`, `date1`, `chamberid`, `status`) VALUES
('9022301810@user', 135, '5c94a79ebb52e', 'Crop', '20', '2019-03-22', '5_chamber', 'Paid'),
('9022301810@user', 136, '5c94a7c9eeadc', 'Crop', '10', '2019-03-22', '5_chamber', 'Paid'),
('9022301810@user', 137, '5c971406cba32', 'Wheat', '20', '2019-03-24', '5_chamber', 'Pending'),
('9022301810@user', 138, '5c9735cf1d6a3', 'Crop', '20', '2019-03-25', '1_chamber', 'Pending'),
('9022301810@user', 139, '5c9735cf1d6a3', 'Crop', '20', '2019-03-25', '2_chamber', 'Pending'),
('9022301810@user', 140, '5c9735cf1d6a3', 'Crop', '5', '2019-03-25', '3_chamber', 'Pending');

-- --------------------------------------------------------

--
-- Table structure for table `chamber_details`
--

CREATE TABLE `chamber_details` (
  `id` varchar(255) NOT NULL,
  `chamber_name` varchar(255) NOT NULL,
  `warehouse_id` varchar(255) NOT NULL,
  `full_capacity` varchar(255) NOT NULL,
  `status` varchar(255) NOT NULL,
  `filled_capacity` varchar(255) NOT NULL,
  `type` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `chamber_details`
--

INSERT INTO `chamber_details` (`id`, `chamber_name`, `warehouse_id`, `full_capacity`, `status`, `filled_capacity`, `type`) VALUES
('0_chamber', 'Chamber 1', '9923874104w1', '20', 'Available', '0', 'Cold'),
('10_chamber', 'Chamber 11', '9923874104w2', '250', 'Available', '0', 'New Category'),
('11_chamber', 'Chamber 12', '9923874104w2', '250', 'Available', '0', 'New Category'),
('12_chamber', 'Chamber 13', '9923874104w2', '250', 'Available', '0', 'New Category'),
('13_chamber', 'Chamber 14', '9923874104w2', '250', 'Available', '0', 'New Category'),
('14_chamber', 'Chamber 15', '9923874104w2', '250', 'Available', '0', 'New Category'),
('15_chamber', 'Chamber 16', '9923874104w2', '250', 'Available', '0', 'New Category'),
('1_chamber', 'Chamber 2', '9923874104w1', '20', 'Unavailable', '20', 'Cold'),
('2_chamber', 'Chamber 3', '9923874104w1', '20', 'Unavailable', '20', 'Cold'),
('3_chamber', 'Chamber 4', '9923874104w1', '20', 'Unavailable', '5', 'Cold'),
('4_chamber', 'Chamber 5', '9923874104w1', '20', 'Available', '0', 'Cold'),
('5_chamber', 'Chamber 6', '9923874104w1', '35', 'Unavailable', '20', 'Wet'),
('6_chamber', 'Chamber 7', '9923874104w2', '250', 'Available', '0', 'New Category'),
('7_chamber', 'Chamber 8', '9923874104w2', '250', 'Available', '0', 'New Category'),
('8_chamber', 'Chamber 9', '9923874104w2', '250', 'Available', '0', 'New Category'),
('9_chamber', 'Chamber 10', '9923874104w2', '250', 'Available', '0', 'New Category');

-- --------------------------------------------------------

--
-- Table structure for table `farmer_crop`
--

CREATE TABLE `farmer_crop` (
  `id` int(10) NOT NULL,
  `farmer_id` varchar(200) NOT NULL,
  `crop_name` varchar(255) NOT NULL,
  `date_from` varchar(255) NOT NULL,
  `date_to` varchar(255) NOT NULL,
  `prefer_climate` varchar(200) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `farmer_crop`
--

INSERT INTO `farmer_crop` (`id`, `farmer_id`, `crop_name`, `date_from`, `date_to`, `prefer_climate`) VALUES
(1, '9022301810@user', 'Wheat', '2018-03-02', '2020-03-02', 'Rainy Season');

-- --------------------------------------------------------

--
-- Table structure for table `farmer_details`
--

CREATE TABLE `farmer_details` (
  `id` varchar(255) NOT NULL,
  `address` varchar(255) NOT NULL,
  `city` varchar(255) NOT NULL,
  `state` varchar(255) NOT NULL,
  `pincode` varchar(255) NOT NULL,
  `profile_complete` int(10) NOT NULL,
  `profile_verified` int(10) NOT NULL,
  `readonly` int(10) NOT NULL,
  `profile_photo_path` varchar(500) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `farmer_details`
--

INSERT INTO `farmer_details` (`id`, `address`, `city`, `state`, `pincode`, `profile_complete`, `profile_verified`, `readonly`, `profile_photo_path`) VALUES
('9022301810@user', 'Kasarvadavali, Thane West, Thane, Maharashtra, India', 'Kasarvadavali, Thane West, Thane, Maharashtra 400615, India', '19.2679379', '72.9711542', 1, 0, 0, '9022301810@user/9022301810@user.png'),
('9765558727@user', '', '', '', '', 0, 0, 0, '');

-- --------------------------------------------------------

--
-- Table structure for table `site_api`
--

CREATE TABLE `site_api` (
  `id` int(11) NOT NULL,
  `api_key` varchar(200) NOT NULL,
  `activate` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `site_api`
--

INSERT INTO `site_api` (`id`, `api_key`, `activate`) VALUES
(1, 'AIzaSyB-quGWafIwDHMoWgZwWpPVNv9Wj92eFQo', 1),
(2, 'AIzaSyCEm_F4ecm0uGNHn7dewoK68X8lfpgLHDk', 0),
(3, 'szdfxghj', 0);

-- --------------------------------------------------------

--
-- Table structure for table `superadmins`
--

CREATE TABLE `superadmins` (
  `username` varchar(200) NOT NULL,
  `password` varchar(200) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `superadmins`
--

INSERT INTO `superadmins` (`username`, `password`) VALUES
('admin', 'admin'),
('admin123', 'admin123');

-- --------------------------------------------------------

--
-- Table structure for table `user_detail`
--

CREATE TABLE `user_detail` (
  `id` varchar(255) NOT NULL,
  `first_name` varchar(255) NOT NULL,
  `last_name` varchar(255) NOT NULL,
  `dob` varchar(255) NOT NULL,
  `mobile_no` varchar(255) NOT NULL,
  `aadhar_no` varchar(255) NOT NULL,
  `password` varchar(255) NOT NULL,
  `role` varchar(255) NOT NULL,
  `phone_verified` int(10) NOT NULL,
  `otp` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `user_detail`
--

INSERT INTO `user_detail` (`id`, `first_name`, `last_name`, `dob`, `mobile_no`, `aadhar_no`, `password`, `role`, `phone_verified`, `otp`) VALUES
('9022301810@user', 'Abhishek', 'Prajapati', '1990-02-06', '9022301810', '902230181012', 'e10adc3949ba59abbe56e057f20f883e', 'Farmer', 1, ''),
('9158452105@user', 'Kiran', 'D', '1998-02-02', '9158452105', '915845210512', 'e10adc3949ba59abbe56e057f20f883e', 'WOwner', 1, ''),
('9765558727@user', 'Lavina', 'Budhwani', '1998-02-06', '9765558727', '976555872712', 'e10adc3949ba59abbe56e057f20f883e', 'Farmer', 0, ''),
('9923874104@user', 'Amit', 'Prajapati', '1998-02-02', '9923874104', '992387410412', 'e10adc3949ba59abbe56e057f20f883e', 'WOwner', 1, '');

-- --------------------------------------------------------

--
-- Table structure for table `warehouse_details`
--

CREATE TABLE `warehouse_details` (
  `id` varchar(255) NOT NULL,
  `warehouse_name` varchar(255) NOT NULL,
  `capacity` varchar(50) NOT NULL,
  `address` varchar(255) NOT NULL,
  `city` varchar(255) NOT NULL,
  `state` varchar(255) NOT NULL,
  `pincode` varchar(255) NOT NULL,
  `no_of_chambers` varchar(255) NOT NULL,
  `activated` int(10) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `warehouse_details`
--

INSERT INTO `warehouse_details` (`id`, `warehouse_name`, `capacity`, `address`, `city`, `state`, `pincode`, `no_of_chambers`, `activated`) VALUES
('9923874104w1', 'APSIT', '135', 'Kasarvadavali, Thane West, Thane, Maharashtra, India', 'Kasarvadavali, Thane West, Thane, Maharashtra 400615, India', '19.2679379', '72.9711542', '6', 1),
('9923874104w2', 'Mulund', '2500', 'Mulund Colony, Mulund West, Mumbai, Maharashtra, India', 'Mulund Colony, Mulund West, Mumbai, Maharashtra, India', '19.168869', '72.9349833', '10', 1);

-- --------------------------------------------------------

--
-- Table structure for table `warehouse_owner`
--

CREATE TABLE `warehouse_owner` (
  `warehouse_id` varchar(255) NOT NULL,
  `wowner_id` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `warehouse_owner`
--

INSERT INTO `warehouse_owner` (`warehouse_id`, `wowner_id`) VALUES
('9923874104w1', '9923874104@user'),
('9923874104w2', '9923874104@user');

-- --------------------------------------------------------

--
-- Table structure for table `warehouse_type`
--

CREATE TABLE `warehouse_type` (
  `id` int(10) NOT NULL,
  `warehouse_owner` varchar(255) NOT NULL,
  `warehouse_id` varchar(255) NOT NULL,
  `warehouse_type` varchar(25) NOT NULL,
  `status` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `warehouse_type`
--

INSERT INTO `warehouse_type` (`id`, `warehouse_owner`, `warehouse_id`, `warehouse_type`, `status`) VALUES
(31, '9923874104@user', '9923874104w1', 'Cold', 'Active'),
(32, '9923874104@user', '9923874104w1', 'Wet', 'Active'),
(33, '9923874104@user', '9923874104w2', 'New Category', 'Active');

-- --------------------------------------------------------

--
-- Table structure for table `wowner_details`
--

CREATE TABLE `wowner_details` (
  `id` varchar(255) NOT NULL,
  `address` varchar(255) NOT NULL,
  `city` varchar(255) NOT NULL,
  `state` varchar(255) NOT NULL,
  `pincode` varchar(255) NOT NULL,
  `profile_complete` int(10) NOT NULL,
  `no_of_warehouses` int(255) NOT NULL,
  `readonly` int(10) NOT NULL,
  `profile_photo_path` varchar(500) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `wowner_details`
--

INSERT INTO `wowner_details` (`id`, `address`, `city`, `state`, `pincode`, `profile_complete`, `no_of_warehouses`, `readonly`, `profile_photo_path`) VALUES
('9158452105@user', 'Arhant Nivas, Baudhwadi, Mhatre Aali', 'THANE', 'Maharashtra', '400701', 1, 0, 0, ''),
('9923874104@user', 'Ghansoli Gaon Main Road, Adishakti Nagar, Gaondevi Wadi, Ghansoli Gaon, Ghansoli, Navi Mumbai, Maharashtra, India', 'Ghansoli Gaon Main Rd, Adishakti Nagar, Talvali, Ghansoli Gaon, Ghansoli, Navi Mumbai, Maharashtra 400701, India', '19.1255123', '72.9985547', 1, 2, 0, '9923874104@user/9923874104@user.png');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `booking`
--
ALTER TABLE `booking`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `chamber_details`
--
ALTER TABLE `chamber_details`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `farmer_crop`
--
ALTER TABLE `farmer_crop`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `farmer_details`
--
ALTER TABLE `farmer_details`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `site_api`
--
ALTER TABLE `site_api`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `user_detail`
--
ALTER TABLE `user_detail`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `warehouse_details`
--
ALTER TABLE `warehouse_details`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `warehouse_type`
--
ALTER TABLE `warehouse_type`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `wowner_details`
--
ALTER TABLE `wowner_details`
  ADD PRIMARY KEY (`id`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `booking`
--
ALTER TABLE `booking`
  MODIFY `id` int(10) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=141;
--
-- AUTO_INCREMENT for table `farmer_crop`
--
ALTER TABLE `farmer_crop`
  MODIFY `id` int(10) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;
--
-- AUTO_INCREMENT for table `site_api`
--
ALTER TABLE `site_api`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;
--
-- AUTO_INCREMENT for table `warehouse_type`
--
ALTER TABLE `warehouse_type`
  MODIFY `id` int(10) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=34;COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
