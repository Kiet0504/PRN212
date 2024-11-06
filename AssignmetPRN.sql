CREATE DATABASE AssignmentPRN;
GO
USE AssignmentPRN;
GO

CREATE TABLE [Users] (
    user_id INT PRIMARY KEY IDENTITY,
    username VARCHAR(50) NOT NULL UNIQUE,
    password VARCHAR(255) NOT NULL
);

CREATE TABLE Playlists (
    playlist_id INT PRIMARY KEY IDENTITY,
    user_id INT NOT NULL,
    name VARCHAR(100) NOT NULL,
    created_at DATETIME DEFAULT GETDATE(),
    FOREIGN KEY (user_id) REFERENCES [Users](user_id) ON DELETE CASCADE
);

CREATE TABLE Songs(
    song_id INT PRIMARY KEY IDENTITY,
    title VARCHAR(255) NOT NULL,
    artist VARCHAR(100),
    album VARCHAR(100),
    genre VARCHAR(50),
    file_path VARCHAR(500) NOT NULL,  -- Đường dẫn đến file nhạc
    created_at DATETIME DEFAULT GETDATE()
);

CREATE TABLE PlaylistSongs (
    playlistsong_id INT PRIMARY KEY IDENTITY,
    playlist_id INT NOT NULL,
    song_id INT NOT NULL,
    added_at DATETIME DEFAULT GETDATE(),
    FOREIGN KEY (playlist_id) REFERENCES Playlists(playlist_id) ON DELETE CASCADE,
    FOREIGN KEY (song_id) REFERENCES Songs(song_id) ON DELETE CASCADE
);

INSERT INTO [Users] (username, password)
VALUES ('thang ', '1');