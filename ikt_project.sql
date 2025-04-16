-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Gép: 127.0.0.1
-- Létrehozás ideje: 2025. Ápr 16. 19:57
-- Kiszolgáló verziója: 10.4.32-MariaDB
-- PHP verzió: 8.2.12

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Adatbázis: `ikt_project`
--

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `chapter`
--

CREATE TABLE `chapter` (
  `id` int(11) NOT NULL,
  `mangaId` int(11) NOT NULL,
  `name` varchar(191) NOT NULL,
  `filepath` varchar(191) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

--
-- A tábla adatainak kiíratása `chapter`
--

INSERT INTO `chapter` (`id`, `mangaId`, `name`, `filepath`) VALUES
(1, 9, 'chapter-1', 'public/manga/one_piece/chapters/chap1/01.jpg');

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `cover`
--

CREATE TABLE `cover` (
  `id` int(11) NOT NULL,
  `mangaId` int(11) NOT NULL,
  `filepath` varchar(191) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

--
-- A tábla adatainak kiíratása `cover`
--

INSERT INTO `cover` (`id`, `mangaId`, `filepath`) VALUES
(3, 9, 'manga/one_piece/OP.png'),
(6, 10, 'manga/my_hero_academia/MHA.png');

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `favorite`
--

CREATE TABLE `favorite` (
  `id` int(11) NOT NULL,
  `userId` int(11) NOT NULL,
  `mangaId` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `manga`
--

CREATE TABLE `manga` (
  `id` int(11) NOT NULL,
  `author` varchar(191) NOT NULL,
  `description` varchar(191) NOT NULL,
  `title` varchar(191) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

--
-- A tábla adatainak kiíratása `manga`
--

INSERT INTO `manga` (`id`, `author`, `description`, `title`) VALUES
(9, 'Eiichiro Oda', 'A great pirate adventure', 'One Piece'),
(10, 'Kohei Horikoshi', 'hero story', 'My Hero academia');

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `page`
--

CREATE TABLE `page` (
  `id` int(11) NOT NULL,
  `chapterId` int(11) NOT NULL,
  `filepath` varchar(191) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

--
-- A tábla adatainak kiíratása `page`
--

INSERT INTO `page` (`id`, `chapterId`, `filepath`) VALUES
(2, 1, 'public/manga/one_piece/chapters/chap1/02.jpg');

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `progress`
--

CREATE TABLE `progress` (
  `id` int(11) NOT NULL,
  `userId` int(11) NOT NULL,
  `mangaId` int(11) NOT NULL,
  `chapterId` int(11) NOT NULL,
  `updateAt` datetime(3) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `token`
--

CREATE TABLE `token` (
  `token` varchar(191) NOT NULL,
  `expiration` datetime(3) NOT NULL,
  `userId` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

--
-- A tábla adatainak kiíratása `token`
--

INSERT INTO `token` (`token`, `expiration`, `userId`) VALUES
('1ba4d47075ab759e6984a62924ea9b873e83c6cff7327ad05c2fbe370facb057', '2025-04-13 13:22:40.717', 2),
('28ce34921f9b36a1660ce33c1d6b7833e69bca5c7a7e3315ec2f9f2163251bc1', '2025-04-13 13:08:46.355', 2),
('29b51de1c21a28519bc54f6e80c41ee0cf8aca2e67dc3b0fed04a390302c955a', '2025-04-13 13:08:36.123', 2),
('2c9b3206925dd2a69cec8bf472d9a163d80a569cb7bcb3e662ea103479024b55', '2025-04-03 07:42:11.267', 1),
('52c862f0955e353cdaa4a6b9f8265ff81bf88b349b0cd5166617ca53c0f8c96f', '2025-04-02 15:29:05.263', 1),
('706527c24778063fa0720fa2ce3d868dc6a665b7840a531421b8e67d683ad8fd', '2025-04-02 15:29:15.343', 1),
('710f061e6ffbc68afa3742d18b0928fc4966c6c1ca463938c541da3ab9679b30', '2025-04-02 15:28:50.624', 1),
('8941aacfda1cbf3d927a374e739a8fc6e342a9c8185a7ad586296448a10330e0', '2025-04-13 13:25:37.078', 2),
('9c1fd39a9b64a1cd2a727b69d3b34ae38e8563a60d7193260296263de9226a1c', '2025-04-13 13:08:55.990', 2),
('b11e8ad1e9ffcf37b83dd6a474657c5db0bbf78dee9925af2eb035539a1f3894', '2025-04-13 13:24:40.170', 2),
('d83beb5a6edcac07fd4088aeea290b6450109b282046450f1c012b4b33eb13cf', '2025-04-04 18:10:13.337', 1),
('fdfc964bae35e4f97295c2b525f99c81a68cfa5c7b2178ac674ad14419bba917', '2025-04-13 13:26:35.440', 2);

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `user`
--

CREATE TABLE `user` (
  `id` int(11) NOT NULL,
  `password` varchar(191) NOT NULL,
  `email` varchar(191) NOT NULL,
  `profilename` varchar(191) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

--
-- A tábla adatainak kiíratása `user`
--

INSERT INTO `user` (`id`, `password`, `email`, `profilename`) VALUES
(1, '$argon2id$v=19$m=65536,t=3,p=4$8N9ILQaXnzKOMKkzAmUzbQ$JcXM47S3HRmWe6ePL4H8FluTsWlaYh8+Jfk5eo5XcqE', 'example@gmail.com', 'luffy'),
(2, '$argon2id$v=19$m=65536,t=3,p=4$1YopxzU47lrq/aDuTg4Khg$b5yVqEZzKOMcL/7Cv4w3lir5/5RMl9QPpz7uLJIYbLs', 'exmaple@gmail.com', 'sanyi');

-- --------------------------------------------------------

--
-- Tábla szerkezet ehhez a táblához `_prisma_migrations`
--

CREATE TABLE `_prisma_migrations` (
  `id` varchar(36) NOT NULL,
  `checksum` varchar(64) NOT NULL,
  `finished_at` datetime(3) DEFAULT NULL,
  `migration_name` varchar(255) NOT NULL,
  `logs` text DEFAULT NULL,
  `rolled_back_at` datetime(3) DEFAULT NULL,
  `started_at` datetime(3) NOT NULL DEFAULT current_timestamp(3),
  `applied_steps_count` int(10) UNSIGNED NOT NULL DEFAULT 0
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_unicode_ci;

--
-- A tábla adatainak kiíratása `_prisma_migrations`
--

INSERT INTO `_prisma_migrations` (`id`, `checksum`, `finished_at`, `migration_name`, `logs`, `rolled_back_at`, `started_at`, `applied_steps_count`) VALUES
('1f3ab419-6a8c-4f68-b370-839b9fa14ef8', '63edf4b1494faa55de6b1641e4e787fcfdf3cfcfc215ca97eaeafe22095f65a4', '2025-03-31 19:27:44.046', '20250331192550_het', NULL, NULL, '2025-03-31 19:27:44.015', 1),
('215a13df-faac-4c9f-8ee3-5c0a703659a8', '5533f774ecd1b89a50b44d4e7d83be05147b3081e376a86776829d165f6d08af', '2025-03-31 19:27:44.005', '20250320094025_sixth', NULL, NULL, '2025-03-31 19:27:43.998', 1),
('24b85a49-02ea-4d95-9290-c0dd6ef73616', 'bf98b44f5ad204603d7b59c71a2909b82249d4b91604466f4097a2a3409cd5b0', '2025-03-31 19:27:43.844', '20250313191232_first', NULL, NULL, '2025-03-31 19:27:43.786', 1),
('358aee64-a4d5-4db8-beb1-e75e5daafaaf', 'b1065e8a72e623008f506a2b62a546975a8543e67e50f2996788035b30cd60d0', '2025-03-31 20:42:10.207', '20250331204210_ten', NULL, NULL, '2025-03-31 20:42:10.199', 1),
('3e9ee59f-d6b0-4984-89ba-5c57d15f3a1c', '55dfeee2ff44ceed6221d677fd5b3c55316f3c8ef641700eb87a2256660a40eb', '2025-04-02 15:29:46.724', '20250402152946_twelve', NULL, NULL, '2025-04-02 15:29:46.718', 1),
('43c68c32-742e-4c50-bb57-f02e4f0b86e2', '39c277f013a633b94ce066a24fe1c0f3a28c9203a83ee0a6321f2d48b92224e5', '2025-04-12 13:00:23.396', '20250409120747_add_favorites', NULL, NULL, '2025-04-12 13:00:23.260', 1),
('5a26c3fc-8f99-4ac2-a390-aa897f3a4061', '5f100f61a9bb38cbd87e9ff9022cd70cddfa18b557807e18f4d59e2f0bc3ce1f', '2025-03-31 19:28:23.798', '20250331192823_nyoc', NULL, NULL, '2025-03-31 19:28:23.759', 1),
('5f4a70e5-340a-4999-bf80-d10f9320c4d5', 'e2ef0079dbb3b66a3eeb1e19741408cdff5a60100d018644331de0bd11547b90', '2025-03-31 20:33:32.122', '20250331203332_kilenc', NULL, NULL, '2025-03-31 20:33:32.111', 1),
('7be2ee1f-4cc3-4f0e-a550-c9294de491be', '730190d9ef10836df919c7298f2158d78b8fdc7ebfb10879a05e26beb69c8ac9', '2025-03-31 19:27:43.997', '20250319155832_fifth', NULL, NULL, '2025-03-31 19:27:43.992', 1),
('9110e889-8cd5-46da-8902-0148fd54f710', 'bf255e00870eea44eb81cc2ff73473b6779add9173f69d50583e15482509ff8e', '2025-03-31 19:27:43.991', '20250319154545_fourth', NULL, NULL, '2025-03-31 19:27:43.859', 1),
('dfce009a-ecae-451b-8524-d66615f339d6', '56c73ba54e3304829aa1471b85001aba500b3ef6f45e4af2f60eee250d969251', '2025-03-31 19:27:43.858', '20250313201636_third', NULL, NULL, '2025-03-31 19:27:43.851', 1),
('e031bf7f-eb84-4227-b237-1c17605fcd2f', '3fef6aa70b51caf823c8ee6f0f5e26b883b96924faa35a15295a4ab3491232d3', '2025-03-31 19:27:43.850', '20250313194238_second', NULL, NULL, '2025-03-31 19:27:43.845', 1),
('e158976b-afc5-446d-a134-caceb439a07a', '2f6fcf06d5c5697c8d7889813a178fdf54bf9bac5b9f5499089a3eeb5882419a', '2025-04-12 13:00:23.576', '20250411140855_add_progress', NULL, NULL, '2025-04-12 13:00:23.399', 1),
('f547e534-012b-4b6a-9564-809f5afd1f76', '7d3f8640e85b4de5853453f3ff7c7ecddd9b88eba9c5838965c6d8d07954cbfd', '2025-04-02 12:59:59.434', '20250402125959_eleventh', NULL, NULL, '2025-04-02 12:59:59.421', 1);

--
-- Indexek a kiírt táblákhoz
--

--
-- A tábla indexei `chapter`
--
ALTER TABLE `chapter`
  ADD PRIMARY KEY (`id`),
  ADD KEY `Chapter_mangaId_fkey` (`mangaId`);

--
-- A tábla indexei `cover`
--
ALTER TABLE `cover`
  ADD PRIMARY KEY (`id`),
  ADD UNIQUE KEY `Cover_mangaId_key` (`mangaId`);

--
-- A tábla indexei `favorite`
--
ALTER TABLE `favorite`
  ADD PRIMARY KEY (`id`),
  ADD UNIQUE KEY `Favorite_userId_mangaId_key` (`userId`,`mangaId`),
  ADD KEY `Favorite_mangaId_fkey` (`mangaId`);

--
-- A tábla indexei `manga`
--
ALTER TABLE `manga`
  ADD PRIMARY KEY (`id`);

--
-- A tábla indexei `page`
--
ALTER TABLE `page`
  ADD PRIMARY KEY (`id`),
  ADD KEY `Page_chapterId_fkey` (`chapterId`);

--
-- A tábla indexei `progress`
--
ALTER TABLE `progress`
  ADD PRIMARY KEY (`id`),
  ADD UNIQUE KEY `Progress_userId_mangaId_key` (`userId`,`mangaId`),
  ADD KEY `Progress_mangaId_fkey` (`mangaId`),
  ADD KEY `Progress_chapterId_fkey` (`chapterId`);

--
-- A tábla indexei `token`
--
ALTER TABLE `token`
  ADD PRIMARY KEY (`token`),
  ADD KEY `Token_userId_fkey` (`userId`);

--
-- A tábla indexei `user`
--
ALTER TABLE `user`
  ADD PRIMARY KEY (`id`),
  ADD UNIQUE KEY `User_email_key` (`email`),
  ADD UNIQUE KEY `User_profilename_key` (`profilename`);

--
-- A tábla indexei `_prisma_migrations`
--
ALTER TABLE `_prisma_migrations`
  ADD PRIMARY KEY (`id`);

--
-- A kiírt táblák AUTO_INCREMENT értéke
--

--
-- AUTO_INCREMENT a táblához `chapter`
--
ALTER TABLE `chapter`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- AUTO_INCREMENT a táblához `cover`
--
ALTER TABLE `cover`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=7;

--
-- AUTO_INCREMENT a táblához `favorite`
--
ALTER TABLE `favorite`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT a táblához `manga`
--
ALTER TABLE `manga`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=11;

--
-- AUTO_INCREMENT a táblához `page`
--
ALTER TABLE `page`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- AUTO_INCREMENT a táblához `progress`
--
ALTER TABLE `progress`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT;

--
-- AUTO_INCREMENT a táblához `user`
--
ALTER TABLE `user`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- Megkötések a kiírt táblákhoz
--

--
-- Megkötések a táblához `chapter`
--
ALTER TABLE `chapter`
  ADD CONSTRAINT `Chapter_mangaId_fkey` FOREIGN KEY (`mangaId`) REFERENCES `manga` (`id`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Megkötések a táblához `cover`
--
ALTER TABLE `cover`
  ADD CONSTRAINT `Cover_mangaId_fkey` FOREIGN KEY (`mangaId`) REFERENCES `manga` (`id`) ON UPDATE CASCADE;

--
-- Megkötések a táblához `favorite`
--
ALTER TABLE `favorite`
  ADD CONSTRAINT `Favorite_mangaId_fkey` FOREIGN KEY (`mangaId`) REFERENCES `manga` (`id`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `Favorite_userId_fkey` FOREIGN KEY (`userId`) REFERENCES `user` (`id`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Megkötések a táblához `page`
--
ALTER TABLE `page`
  ADD CONSTRAINT `Page_chapterId_fkey` FOREIGN KEY (`chapterId`) REFERENCES `chapter` (`id`) ON UPDATE CASCADE;

--
-- Megkötések a táblához `progress`
--
ALTER TABLE `progress`
  ADD CONSTRAINT `Progress_chapterId_fkey` FOREIGN KEY (`chapterId`) REFERENCES `chapter` (`id`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `Progress_mangaId_fkey` FOREIGN KEY (`mangaId`) REFERENCES `manga` (`id`) ON DELETE CASCADE ON UPDATE CASCADE,
  ADD CONSTRAINT `Progress_userId_fkey` FOREIGN KEY (`userId`) REFERENCES `user` (`id`) ON DELETE CASCADE ON UPDATE CASCADE;

--
-- Megkötések a táblához `token`
--
ALTER TABLE `token`
  ADD CONSTRAINT `Token_userId_fkey` FOREIGN KEY (`userId`) REFERENCES `user` (`id`) ON DELETE CASCADE ON UPDATE CASCADE;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
